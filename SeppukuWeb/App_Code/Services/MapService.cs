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
            // 1: wyciągam z bazy wszystkie pola należące do danej mapy

            // 2: wstawiam wyciągnięte pola do tablicy dwuwymiarowej

            // 3: liczę środek ciężkości wszystkich dotychczasowych pól

            // 4: dla każdego pola na mapie: sprawdzam czy jest wolne, oraz sprawdzam
            //    czy w odległości mniejszej lub równej od 2 nie ma żadnych zajętych pól, ale
            //    w odległości 3 już są zajęte pola. 
            //    Dla pól tego typu wybieram pole z minimalną odległością od środka ciężkości.
            //    Na tym polu powstanie nowe królestwo.
            throw new NotImplementedException();
        }
    }
}