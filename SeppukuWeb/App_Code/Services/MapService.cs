using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class MapService
    {
        public int Add(Map o)
        {
            return new MapDAO().Add(o);
        }

        public void Update(Map o)
        {
            new MapDAO().Update(o);
        }

        public void Delete(Map o)
        {
            new MapDAO().Delete(o.MapId);
        }

        public Map GetById(int mapId)
        {
            return new MapDAO().GetById(mapId);
        }

        public IList<Map> GetAll()
        {
            return new MapDAO().GetAll();
        }

        public void InitializeKingdom(int mapId, int kingdomId)
        {

            int actMapSize = new FieldDAO().GetByMapId(mapId).Count;

            actMapSize /= 9;

            int x=0;
            int y=0;

            int xDone = 0;
            int yDone = 0;

            int xDir = 1;
            int yDir = 1;

            int xSize = 1;
            int ySize = 1;

            bool xMod = true;

            for (int i = 1; i < actMapSize+1; i++)
            {
                if (xMod)
                {
                    x += xDir*2;
                    xDone++;
                    if (xDone == xSize)
                    {
                        xDir *= -1;
                        xSize++;
                        xDone = 0;
                        xMod = false;
                    }
                }
                else
                {
                    y += yDir*2;
                    yDone++;
                    if (yDone == ySize)
                    {
                        yDir *= -1;
                        ySize++;
                        yDone = 0;
                        xMod = true;
                    }
                }
            }


           
            System.Text.StringBuilder name = new System.Text.StringBuilder();
            String[] area = {"Pola", "Dolina", "Wzgórza", "Łąki", "Las", "Mokradła", "Góry"};
            String[] describe = {"Mrocznych","Wichrowych", "Wesołych", "Wielkich", "Małych", "Smutnych", "Krwawych", "Czarnych", "Kolorowych", "Białych", "Żelaznych", "Stalowych", "Miedzianych", "Srebrnych", "Złotych", "Diamentowych"};
            String[] thing = {"Ostrzy", "Kucyków","Teściochych","Wilków","Wron","Szkieletów","Noży", "Chłopów", "Włóczni","Mieczy","Bibliotekarzy", "Krów"};

            Random rand = new Random();

            name.Append(area[rand.Next(area.Length)]);
            name.Append(" ");
            name.Append(describe[rand.Next(describe.Length)]);
            name.Append(" ");
            name.Append(thing[rand.Next(thing.Length)]);

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    Field field = new Field();
                    field.FieldX = i;
                    field.FieldY = j;

                    if(i==x && j==y) field.KingdomId = kingdomId;

                    field.MapId = mapId;
                    field.FieldName = name.ToString();

                    new FieldDAO().Add(field);
                }
            }

            // 1: wyciągam z bazy wszystkie pola należące do danej mapy

            // 2: wyciagam rozmiar

            // 3: wyliczam gzie powinien sie znalesc srodek nowego krolestwa(dodawane po spirali)

            // 4: dodaje nowe krolestwo o rozmiarze i i dodaje obwodke
        }
    }
}