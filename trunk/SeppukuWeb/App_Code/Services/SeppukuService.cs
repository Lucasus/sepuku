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
		public List<OrderInfo> orders;
		public int rice;

		public MapModel(int rice, List<TileInfo> tiles, List<Owner> players, List<OrderInfo> orders)
		{
			this.rice = rice;
			this.tiles = tiles;
			this.players = players;
			this.orders = orders;
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

	public struct OrderInfo
	{
		public string orderType;
		public int sourceTileId;
		public int destinationTileId;
		public int unitCount;
		public int orderCost;

		public OrderInfo(string orderType, int sourceTileId, int destinationTileId, int unitCount, int orderCost)
		{
			this.orderType = orderType;
			this.sourceTileId = sourceTileId;
			this.destinationTileId = destinationTileId;
			this.unitCount = unitCount;
			this.orderCost = orderCost;
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

		return new GameStateUpdater().UpdateAll();
	}

	[WebMethod(EnableSession=true)]
	public void addOrder(OrderInfo orderInfo)
	{
		OrderType orderType = new OrderTypeDAO().GetByName(orderInfo.orderType);

		Order orderToAdd = new Order();
		orderToAdd.Count = 10;
		orderToAdd.KingdomId = 1;
		orderToAdd.Epoch = 1;
		orderToAdd.FieldId = 1;//orderInfo.sourceTileId;
		orderToAdd.FieldIdDestination = 1;//orderInfo.destinationTileId;
		orderToAdd.OrderTypeId = 1;//orderType.OrderTypeId;
		new OrderDAO().Add(orderToAdd);
	}

	[WebMethod(EnableSession=true)]
	public void removeOrder(OrderInfo orderInfo)
	{
		
	}

	[WebMethod(EnableSession=true)]
	public MapModel GetMapModel() 
	{
        User user = CurrentUser.Current;
        Kingdom userKingdom = new KingdomDAO().GetByUserId(user.UserId);

        IList<Kingdom> kingdoms = new KingdomDAO().GetByMapId(userKingdom.MapId);

        List<Owner> players = new List<Owner>();

        Random random = new Random();
        
        foreach (Kingdom k in kingdoms)
        {
            if (k.KingdomId == userKingdom.KingdomId)
            {
                players.Add(new Owner(k.KingdomId, k.KingdomName, "#FF0000"));
            }
            else
            {
                players.Add(new Owner(k.KingdomId, k.KingdomName, String.Format("#{0:X6}", random.Next(0x1000000))));
            }
        }

        List<TileInfo> tiles = new List<TileInfo>();

        IList<Field> fields = new FieldDAO().GetByMapId(userKingdom.MapId);


        foreach (Field field in fields)
        {
            IList<Unit> units = new UnitDAO().GetFromArea(field.MapId, field.FieldX, field.FieldY, 1, 1);
            int unitCount = 0;
            foreach (Unit u in units)
            {
                unitCount += u.Count;
            }

            tiles.Add(new TileInfo(field.FieldId, field.FieldX, field.FieldY, field.FieldName, field.KingdomId, unitCount));
        }
	
	
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Orders need to be taken away from the database too !!!!!!!!!!!!!!!!!!1
		List<OrderInfo> orders = new List<OrderInfo>();
		orders.Add(new OrderInfo("Defend",1,1,5,0));
        //int rice = 1000;

        //List<Owner> players = new List<Owner>();
		
        //Owner owner1 = new Owner(1, "Moose", "#ff0000");
        //Owner owner2 = new Owner(2, "Lucas", "#00ff00");

        //players.Add(owner1);
        //players.Add(owner2);

        //List<TileInfo> tiles = new List<TileInfo>();

        //tiles.Add(new TileInfo(1,1,1,"Krwawe wzgórza", owner1.playerId, 5));
        //tiles.Add(new TileInfo(2,2,1,"MooseVille", owner1.playerId, 5));
        //tiles.Add(new TileInfo(3,2,2,"Grunwald", owner1.playerId, 5));
        //tiles.Add(new TileInfo(4,1,2,"Bździochy dolne", null, 5));
        //tiles.Add(new TileInfo(5,3,4,"Cukierkowa Dolina", owner2.playerId, 10));
        //tiles.Add(new TileInfo(6,5,5,"Wilczy Szaniec", owner2.playerId, 10));

		return new MapModel(userKingdom.KingdomResources, tiles, players, orders);
	}
}

