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

using SeppukuMap.Events;

namespace SeppukuMap.Model
{
	public class SeppukuMapTileModel
	{
		public int tileId;
		public int x;
		public int y;
		public Player owner;
		public string name;
		public SeppukuMapModel mapModel;

		private int gatherers;
		public int Gatherers{
			get{
				return gatherers;
			}
			set{
				gatherers = value;
				if(this.workerDistributionChange != null)
					workerDistributionChange(this, null);
			}
		}

		public delegate void OrderEventHandler(object sender, OrderEventArgs e);
		public event OrderEventHandler orderRemoved;
		public event OrderEventHandler orderAdded;
		public event OrderEventHandler orderSelected;
		public event OrderEventHandler orderDeselected;

		public event EventHandler select;
		public event EventHandler deselct;
		public event EventHandler workerDistributionChange;

		public SeppukuMapTileModel(SeppukuMapModel mapModel, int tileId, int x, int y, Player owner, String name, int gatherers)
		{
			this.mapModel = mapModel;
			this.tileId = tileId;
			this.x = x;
			this.y = y;
			this.owner = owner;
			this.name = name;
			this.gatherers = gatherers;
		}

		public void selected()
		{
			if(this.select != null)
				this.select(this, null);
		}
		
		public void deselected()
		{
			if(this.deselct != null)
				this.deselct(this, null);
		}

		public void removeOrder(IOrder order)
		{
			if(this.orderRemoved != null)
				this.orderRemoved(this, new OrderEventArgs(order));
		}

		public void addOrder(IOrder order)
		{
			if(this.orderAdded != null)
				this.orderAdded(this, new OrderEventArgs(order));
		}

		public void selectOrder(IOrder order)
		{
			if(this.orderSelected != null)
				this.orderSelected(this, new OrderEventArgs(order));
		}

		public void deselectOrder(IOrder order)
		{
			if(this.orderDeselected != null)
				this.orderDeselected(this, new OrderEventArgs(order));
		}
	}
}
