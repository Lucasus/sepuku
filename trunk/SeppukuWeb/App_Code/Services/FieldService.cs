using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class FieldService
    {
        public int Add(Field o)
        {
            return new FieldDAO().Add(o);
        }

        public Field GetByXY(int x, int y)
        {
            return new FieldDAO().GetByXY(x, y);
        }
    }
}