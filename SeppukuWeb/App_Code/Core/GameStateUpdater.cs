using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;


namespace Seppuku.Core
{
    public class GameStateUpdater
    {
        // ile zbiera pojedynczy chlopek
        const int RICE_BY_ONE_MAN = 50;

        public String UpdateAll()
        {
            IList<Map> maps = new MapDAO().GetAll();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (Map m in maps)
            {
                sb.Append(Update(m.MapId));
            }

            return sb.ToString();
        }

        public String Update(int MapId)
        {
            IList<Field> fields = new FieldDAO().GetByMapId(MapId);
            Epoch epoch = new EpochDAO().GetCurrentByMapId(MapId);

            // wypuszczenie wojsk z pól
            IList<Order> orders = new OrderDAO().GetByEpoch(epoch.EpochId);
            foreach (Order o in orders)
            {
                if (o.OrderTypeName.Equals("Attack") || o.OrderTypeName.Equals("Defend"))
                {
                    Field f = new FieldDAO().GetById(o.FieldId);

                    Dictionary<int, int> unitModifier = new Dictionary<int, int>();
                    unitModifier[o.UnitTypeId] = -o.Count;
                    UnitUpdate(f.KingdomId, f, unitModifier);
                }
            }
            

            // rozpatrywanie rozkazów
            foreach (Field field in fields)
            {
                IList<Order> ordersAll = new OrderDAO().GetByFieldEpoch(epoch.EpochId, field.FieldId);
                IList<Order> orderAttack = new List<Order>();
                IList<Order> orderDefend = new List<Order>();
                IList<Order> orderReqruit = new List<Order>();
                IList<Order> orderCollectRice = new List<Order>();


                // Podział rozkazów według rodzaju
                foreach (Order order in ordersAll)
                {
                    if (order.OrderTypeName.Equals("Attack"))
                    {
                        orderAttack.Add(order);
                    }
                    else if (order.OrderTypeName.Equals("Defend"))
                    {
                        orderDefend.Add(order);
                    }
                    else if (order.OrderTypeName.Equals("Reqruit"))
                    {
                        orderReqruit.Add(order);
                    }
                    else if (order.OrderTypeName.Equals("Collect"))
                    {
                        orderDefend.Add(order);
                    }
                }

                // królestwo do którego naley pole na początku tury
                Kingdom startKingdom = new KingdomDAO().GetInfoById(field.KingdomId);


                // zbieranie ryżu
                int collectedRice = 0;
                foreach (Order o in orderCollectRice)
                {
                    collectedRice += o.Count * RICE_BY_ONE_MAN;
                }
                startKingdom.KingdomResources += collectedRice;
                new KingdomDAO().Update(startKingdom);



                // rekrutacja 
                Dictionary<int, int> unitModifier = new Dictionary<int, int>();
                foreach (Order o in orderReqruit)
                {
                    if(unitModifier.ContainsKey(o.UnitTypeId))
                    {
                        unitModifier[o.UnitTypeId] += o.Count;
                    }
                    else
                    {
                        unitModifier[o.UnitTypeId] = 0;
                    }
                }
                UnitUpdate(startKingdom.KingdomId, field, unitModifier);

               
                // af[kingdom][unitType] = count
                Dictionary<int, Dictionary<int,int>> attackForces = new Dictionary<int, Dictionary<int,int>>();
                foreach (Order o in orderDefend.Concat(orderAttack))
                {
                    if(!attackForces.ContainsKey(o.KingdomId))
                    {
                        attackForces[o.KingdomId] = new Dictionary<int, int>();
                    }

                    if (attackForces[o.KingdomId].ContainsKey(o.UnitTypeId))
                    {
                        attackForces[o.KingdomId][o.UnitTypeId] += o.Count;
                    }
                    else
                    {
                        attackForces[o.KingdomId][o.UnitTypeId] = o.Count;
                    }  
                }


                int winner = Battle(attackForces);

                if (winner == 0)
                {
                    // nic sie nie dzieje
                    // wszyscy bioracy udzial w walkach zostali wycieci w pień, więc nie ma kto wrócić na pole
                }
                else if (winner == startKingdom.KingdomId)
                {
                    UnitUpdate(startKingdom.KingdomId, field, attackForces[startKingdom.KingdomId]);
                }
                else
                {

                    UnitUpdate(winner, field, attackForces[winner]);
                }

            }

            return "Hello world";

            // 1: wyciągnąc z bazy wszystkie pola danej mapy
            // 2: Dla każdego pola wyciągnąc jego rozkazy
            // 3: Rozdzielić rozkazy według typu
            // 4: Rozpatrzyć zbieranie ryżu
            // 5: Rozpatrzyc rekrutacje
            // 6: Rozpatrzec ataki i obrone
        }


        // af[kingdom][unitType] = count
        public int Battle(Dictionary<int, Dictionary<int, int>> attackForces)
        {
            
            Dictionary<int,UnitType> unitTypes = new Dictionary<int,UnitType>();
            
            foreach(UnitType ut in new UnitTypeDAO().GetAll())
            {
                unitTypes.Add(ut.UnitTypeId,ut);
            }

            while (attackForces.Count > 1)
            {
                // ap[kingdom] = power
                // wyliczenie sily ataku kazdej ze stron konfliktutu
                // każdy bije w każdego z równa siłą
                Dictionary<int, double> attackPower = new Dictionary<int, double>();
                foreach (int kingdom in attackForces.Keys)
                {
                    attackPower[kingdom] = 0.0;

                    foreach (int ut in attackForces[kingdom].Keys) 
                    {
                        attackPower[kingdom] += unitTypes[ut].UnitTypePower * attackForces[kingdom][ut];
                    }

                    attackPower[kingdom] /= attackForces.Count;
                }

                foreach (int kingdomD in attackForces.Keys)
                {
                    foreach (int kingdomA in attackForces.Keys)
                    {
                        if(kingdomA != kingdomD)
                        {
                            foreach (int ut in attackForces[kingdomD].Keys)
                            {
                                attackForces[kingdomD][ut] -= (int)(attackPower[kingdomA] / attackForces[kingdomD].Keys.Count / unitTypes[ut].UnitTypeHealthPoint);
                            }
                        }
                    }

                    
                   
                    foreach (int ut in attackForces[kingdomD].Keys)
                    {
                        if(attackForces[kingdomD][ut] < 1)
                        {
                            attackForces[kingdomD].Remove((ut));
                        }
                    }

                    if (attackForces[kingdomD].Count < 1)
                    {
                        attackForces.Remove(kingdomD);
                    }
                }


            }

            // jeśli na polu bitwy został dokładnie jeden uczestnik to on wygrał
            if (attackForces.Count == 1)
            {
                return attackForces.Keys.First<int>();
            }

            // jeśli nikt nie pozostał na polu bitwy wygrywa obrońca
            return 0;
        }


        //unitsToUpdate[unitType] = modifier
        public void UnitUpdate(int kingdom, Field field, Dictionary<int, int> unitsToUpdate)
        {
            IList<Unit> units = new UnitDAO().GetFromArea(field.MapId, field.FieldX, field.FieldY, 1, 1);

            HashSet<int> done = new HashSet<int>();

            foreach (Unit u in units)
            {
                bool mod = false;

                if (u.KingdomId != kingdom)
                {
                    mod = true;
                    u.Count = 0;
                }
                if (unitsToUpdate.ContainsKey(u.UnitTypeId))
                {
                    u.Count += unitsToUpdate[u.UnitTypeId];
                    done.Add(u.UnitTypeId);
                    mod = true;
                }

                //jesli zmodyfikowany to update
                if (mod)
                {
                    if (u.Count < 1)
                    {
                        new UnitDAO().Remove(u.UnitId);
                    }
                    else
                    {
                        new UnitDAO().Update(u);
                    }
                }
            }

            foreach (int ut in unitsToUpdate.Keys)
            {
                if (!done.Contains(ut))
                {
                    Unit newUnit = new Unit();
                    newUnit.Count = unitsToUpdate[ut];
                    newUnit.FieldId = field.FieldId;
                    newUnit.KingdomId = kingdom;
                    newUnit.UnitName = "Nie wiem po co jest to pole";
                    newUnit.UnitTypeId = ut;

                    new UnitDAO().Add(newUnit);
                }
            }

        }

    }




}