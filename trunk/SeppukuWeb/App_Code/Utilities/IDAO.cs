using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DN.Core
{
    public interface IDAO<T>
    {   
        T DataObject { get; set; }
        void FillParametersFromProperties(Database db,ref DbCommand cmd);
        T GetFromRow(DataRow dr);

    }
}