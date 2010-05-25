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

namespace SeppukuMap.Model
{
	public class SeppukuModel
	{
		public int currentPlayerId;

		public SeppukuMapModel map;
		public Dictionary<int, Player> players;

		private ObservableCollection<IOrder> orders;
		public ObservableCollection<IOrder> Orders
		{
			get{
				return orders;
			}
		}

		public event EventHandler Ready;

		public SeppukuModel(int currentPlayerId)
		{
			this.currentPlayerId = currentPlayerId;
			players = new Dictionary<int,Player>();
			this.orders = new ObservableCollection<IOrder>();
			map = new SeppukuMapModel(this);
			map.Ready += this.onReady;
		}

		public void addOrder(IOrder order)
		{
			this.orders.Add(order);
			order.doChanges();
		}

		public void removeOrder(IOrder order)
		{
			order.undoChanges();
			this.orders.Remove(order);
		}

		public void onReady(object sender, EventArgs e)
		{
			if(this.Ready != null)
				this.Ready(this, null);
		}
	}
}
