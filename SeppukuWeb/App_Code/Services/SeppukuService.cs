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
	public struct Owner
	{
		public int playerId;
		public string playerName;
		public string playerColor;
	
		public Owner(int playerId, string playerName, string playerColor)
		{
			this.playerId = playerId;
			this.playerColor = playerColor;
			this.playerName = playerName;
		}
	}

	public struct TileInfo
	{
		public int x;
		public int y;
		public string name;
		public Owner? owner;
		public int numberOfWorkers;

		public TileInfo(int x, int y, string name, Owner? owner, int numberOfWorkers)
		{
			this.x = x;
			this.y = y;
			this.name = name;
			this.owner = owner;
			this.numberOfWorkers = numberOfWorkers;
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
		
		Owner owner1 = new Owner(1, "Moose", "#ff0000");
		Owner owner2 = new Owner(2, "Lucas", "#00ff00");

		tiles.Add(new TileInfo(1,1,"Krwawe wzgórza", owner1, 5));
		tiles.Add(new TileInfo(2,1,"MooseVille", owner1, 5));
		tiles.Add(new TileInfo(1,2,"Bździochy dolne", null, 5));
		tiles.Add(new TileInfo(3,4,"Cukierkowa Dolina", owner2, 10));
		tiles.Add(new TileInfo(5,5,"Wilczy Szaniec", owner2, 10));
		return  tiles;
	}
}

