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
    }
}