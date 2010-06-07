using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;


namespace Seppuku.Core
{
    class Rectangle
    {
        public int minX = 99999;
        public int minY = 999999;
        public int maxX = -99999;
        public int maxY = -99999;


        public bool CollidesWith(Rectangle rec, int margine)
        {
            return (this.minX - margine < rec.maxX && this.maxX + margine > rec.minX && this.minY - margine < rec.maxY && this.maxY + margine > rec.minY);
        }
    }

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
                if (o.OrderTypeName.Equals("Move") || o.OrderTypeName.Equals("Defend"))
                {
                    Field f = new FieldDAO().GetById(o.FieldId);

                    Dictionary<int, int> unitModifier = new Dictionary<int, int>();
                    unitModifier[o.UnitTypeId] = -o.Count;
                    UnitUpdate(f.KingdomId, f, unitModifier);
                }
            }
            
            Dictionary<int,UnitType> unitTypes = new Dictionary<int,UnitType>();
            
            foreach(UnitType ut in new UnitTypeDAO().GetAll())
            {
                unitTypes.Add(ut.UnitTypeId,ut);
            }

            // rozpatrywanie rozkazów
            foreach (Field field in fields)
            {
                IList<Order> ordersAll = new OrderDAO().GetByFieldEpoch(epoch.EpochId, field.FieldId);
                if (ordersAll.Count > 0)
                {
                    IList<Order> orderMove = new List<Order>();
                    IList<Order> orderDefend = new List<Order>();
                    IList<Order> orderBuy = new List<Order>();
                    IList<Order> orderGather = new List<Order>();


                    // Podział rozkazów według rodzaju
                    foreach (Order order in ordersAll)
                    {
                        if (order.OrderTypeName.Equals("Move"))
                        {
                            orderMove.Add(order);
                        }
                        else if (order.OrderTypeName.Equals("Defend"))
                        {
                            orderDefend.Add(order);
                        }
                        else if (order.OrderTypeName.Equals("Buy"))
                        {
                            orderBuy.Add(order);
                        }
                        else if (order.OrderTypeName.Equals("Gather"))
                        {
                            orderGather.Add(order);
                        }
                    }

                    // królestwo do którego naley pole na początku tury
                    Kingdom startKingdom = new KingdomDAO().GetInfoById(field.KingdomId);

                    if (startKingdom.KingdomId!=0)
                    {

                        // zbieranie ryżu
                        int collectedRice = 0;
                        foreach (Order o in orderGather)
                        {
                            collectedRice += o.Count * RICE_BY_ONE_MAN;
                        }
                        startKingdom.KingdomResources += collectedRice;
                        



                        // rekrutacja 
                        Dictionary<int, int> unitModifier = new Dictionary<int, int>();
                        int toPay = 0;
                        foreach (Order o in orderBuy)
                        {
                            if (unitModifier.ContainsKey(o.UnitTypeId))
                            {
                                unitModifier[o.UnitTypeId] += o.Count;
                            }
                            else
                            {
                                unitModifier[o.UnitTypeId] = o.Count;
                            }
                            toPay += o.Count * unitTypes[o.UnitTypeId].UnitTypeCost;
                        }
                        UnitUpdate(startKingdom.KingdomId, field, unitModifier);
                        
                        startKingdom.KingdomResources -= toPay;
                        new KingdomDAO().Update(startKingdom);
                    }

                    // af[kingdom][unitType] = count
                    Dictionary<int, Dictionary<int, int>> attackForces = new Dictionary<int, Dictionary<int, int>>();
                    foreach (Order o in orderDefend.Concat(orderMove))
                    {
                        if (!attackForces.ContainsKey(o.KingdomId))
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
                        field.KingdomId = winner;
                        new FieldDAO().Update(field);
                        UnitUpdate(winner, field, attackForces[winner]);
                    }

                }


                
            }
            new EpochDAO().Add(MapId);

            this.DiplomacyStatusUpdate(MapId,fields);
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

        public void DiplomacyStatusUpdate(int mapId, IList<Field> fields)
        {
            IList<Kingdom> kingdoms = new KingdomDAO().GetByMapId(mapId);

            Dictionary<int, Rectangle> kingdomsArea = new Dictionary<int, Rectangle>();

            foreach (Field field in fields)
            {
                if (!kingdomsArea.ContainsKey(field.KingdomId))
                {
                    kingdomsArea[field.KingdomId] = new Rectangle();
                }

                if (field.FieldX > kingdomsArea[field.KingdomId].maxX) kingdomsArea[field.KingdomId].maxX = field.FieldX;
                if (field.FieldY > kingdomsArea[field.KingdomId].maxY) kingdomsArea[field.KingdomId].maxY = field.FieldY;

                if (field.FieldX < kingdomsArea[field.KingdomId].minX) kingdomsArea[field.KingdomId].minX = field.FieldX;
                if (field.FieldY < kingdomsArea[field.KingdomId].minY) kingdomsArea[field.KingdomId].minY = field.FieldY;
            }


            foreach (Kingdom kingdom in kingdoms)
            {
                IList<Diplomacy> diplomacy = new DiplomacyDAO().GetByUserId(kingdom.UserId);

                foreach (Kingdom kingdomA in kingdoms)
                {
                    if(kingdomsArea[kingdom.KingdomId].CollidesWith(kingdomsArea[kingdomA.KingdomId],2)){
                        bool mustAdd = true;
                        foreach (Diplomacy dip in diplomacy)
                        {
                            if (dip.SecondaryUserId == kingdomA.UserId) mustAdd = false;
                        }

                        if (mustAdd)
                        {
                            Diplomacy dip = new Diplomacy();
                            dip.MainUserId = kingdom.UserId;
                            dip.SecondaryUserId = kingdomA.UserId;
                            dip.DiplomacyStatusId = 1;// hardcode, nie che mi sie znowu do bazy dodawac pierdolowatej metody, w bazie najlepiej by pod tym id byla wojna

                            new DiplomacyDAO().Add(dip);
                        }
                    }
                }

            }

        }



        
    }




}