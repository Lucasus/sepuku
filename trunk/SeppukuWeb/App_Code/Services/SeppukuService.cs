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

	public struct MapModel
	{
		public List<TileInfo> tiles;
		public List<Owner> players;
		public int rice;

		public MapModel(int rice, List<TileInfo> tiles, List<Owner> players)
		{
			this.rice = rice;
			this.tiles = tiles;
			this.players = players;
		}
	}

	public struct TileInfo
	{
		public int tileId;
		public int x;
		public int y;
		public string name;
		public int? ownerId;
		public int numberOfWorkers;

		public TileInfo(int tileId, int x, int y, string name, int? ownerId, int numberOfWorkers)
		{
			this.tileId = tileId;
			this.x = x;
			this.y = y;
			this.name = name;
			this.ownerId = ownerId;
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
	public MapModel GetMapModel() 
	{
		int rice = 1000;

		List<Owner> players = new List<Owner>();
		
		Owner owner1 = new Owner(1, "Moose", "#ff0000");
		Owner owner2 = new Owner(2, "Lucas", "#00ff00");

		players.Add(owner1);
		players.Add(owner2);

		List<TileInfo> tiles = new List<TileInfo>();

		tiles.Add(new TileInfo(1,1,1,"Krwawe wzgórza", owner1.playerId, 5));
		tiles.Add(new TileInfo(2,2,1,"MooseVille", owner1.playerId, 5));
		tiles.Add(new TileInfo(3,2,2,"Grunwald", owner1.playerId, 5));
		tiles.Add(new TileInfo(4,1,2,"Bździochy dolne", null, 5));
		tiles.Add(new TileInfo(5,3,4,"Cukierkowa Dolina", owner2.playerId, 10));
		tiles.Add(new TileInfo(6,5,5,"Wilczy Szaniec", owner2.playerId, 10));
		return new MapModel(rice, tiles, players);
	}
}

