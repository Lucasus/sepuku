﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Seppuku.Core;
using Seppuku.Domain;
using Seppuku.DAO;

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
	
	[WebMethod(EnableSession=true)]
	public String UpdateGameState() 
	{
		//Add some sort of authorization here!!!!
		return  "Hello World";
	}
}
