using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using DN.Core;
using DN.Domain;
using DN.DAO;

[WebService(Namespace = "http://seppuku.pl/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SeppukuService : System.Web.Services.WebService 
{
    [WebMethod(EnableSession=true)]
    public List<User> GetUsers() 
    {
        return null;
    }
}

