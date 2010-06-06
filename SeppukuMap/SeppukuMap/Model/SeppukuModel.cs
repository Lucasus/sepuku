using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using SeppukuMap.Events;
using SeppukuMap.SeppukuService;

namespace SeppukuMap.Model
{
	public class SeppukuModel
	{
		public int currentPlayerId;

		public SeppukuMapModel map;
		public Dictionary<int, Player> players;

		private int riceNumber;
		public int RiceNumber{
			get{
				return riceNumber;
			}
			set{
				this.riceNumber = value;
				if(this.RiceNumberChanged != null)
					this.RiceNumberChanged(this, null);
			}
		}

		private ObservableCollection<IOrder> orders;
		public ObservableCollection<IOrder> Orders
		{
			get{
				return orders;
			}
		}

		public event EventHandler Ready;
		public event EventHandler RiceNumberChanged;

		//public delegate void OrderEventHandler(object sender, OrderEventArgs e);
		//public event OrderEventHandler OrderRemoved;
		//public event OrderEventHandler OrderAdded;

		public SeppukuModel(int currentPlayerId)
		{
			this.currentPlayerId = currentPlayerId;
			players = new Dictionary<int,Player>();
			this.orders = new ObservableCollection<IOrder>();

			SeppukuServiceSoapClient client = new SeppukuServiceSoapClient();
			client.GetMapModelCompleted += this.onDataLoad;
			client.GetMapModelAsync();
		}

		public void addOrder(IOrder order)
		{
			IOrder similiarOrder = null;
			foreach(IOrder prevOrder in orders)
			{
				if(order.Source == prevOrder.Source && order.Type == prevOrder.Type && order.Destination == prevOrder.Destination)
				{
					similiarOrder = prevOrder;
					break;
				}
			}

			if(similiarOrder != null)
			{
				similiarOrder.undoChanges(this);
				this.orders.Remove(similiarOrder);
				order.join(similiarOrder);
			}
			this.orders.Add(order);
			order.doChanges(this);
			
			order.Source.addOrder(order);
		}

		public void removeOrder(IOrder order)
		{
			if(this.orders.Contains(order))
			{
				order.undoChanges(this);
				this.orders.Remove(order);
			}

			order.Source.removeOrder(order);
		}

		public void onDataLoad(object sender, GetMapModelCompletedEventArgs e)
		{
			MapModel data = (MapModel) e.Result;

			this.riceNumber = data.rice;

			foreach(Owner player in data.players)
			{
				players.Add(player.playerId, new Player(player.playerName,player.playerColor, player.playerId));
			}

			map = new SeppukuMapModel(this, data.tiles);
			
			foreach(OrderInfo order in data.orders)
			{
				IOrder tempOrder = null;

				if(order.orderType == "Buy")
				{
					tempOrder = new BuyOrder(map.getTileById(order.sourceTileId), order.unitCount);
				}
				else if(order.orderType == "Defend")
				{
					tempOrder = new DeffendOrder(map.getTileById(order.sourceTileId), order.unitCount);
				}
				else if(order.orderType == "Gather")
				{
					tempOrder = new GatherOrder(map.getTileById(order.sourceTileId), order.unitCount);
				}
				else if(order.orderType == "Move")
				{
					tempOrder = new MoveOrder(map.getTileById(order.sourceTileId), map.getTileById(order.destinationTileId), order.unitCount);
				}

				this.Orders.Add(tempOrder);
			}

			if(this.Ready != null)
				this.Ready(this, null);
		}
	}
}
