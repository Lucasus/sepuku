using System;
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
	public struct TileInfo
	{
		public int x;
		public int y;
		public string name;

		public TileInfo(int x, int y, string name)
		{
			this.x = x;
			this.y = y;
			this.name = name;
		}
	}

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

	[WebMethod(EnableSession=true)]
	public List<TileInfo> GetTiles() 
	{
		List<TileInfo> tiles = new List<TileInfo>();
		
		tiles.Add(new TileInfo(1,1,"Krwawe wzgórza"));
		tiles.Add(new TileInfo(3,4,"Cukierkowa Dolina"));

		return  tiles;
	}
}

