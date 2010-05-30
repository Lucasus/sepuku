using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using SeppukuMap.Model;
using SeppukuMap.Events;

namespace SeppukuMap
{
	public partial class PlayableTile : UserControl
	{
		public MapTileOrderDecals orderDecals;

		public SeppukuMapTileModel model;
		public SeppukuMapTiles map;

		private String tileName = "";
		public String TileName
		{
			get{
				return tileName;
			}
			set
			{
				tileName = value;
			}
		}

		public PlayableTile(SeppukuMapTiles map, SeppukuMapTileModel model): this()
		{
			this.map = map;
			this.model = model;
			this.model.select += this.onSelect;
			this.model.deselct += this.onDeselect;
			this.model.orderAdded += this.onOrderAdded;
			this.model.orderRemoved += this.onOrderRemoved;
			this.model.orderSelected += this.onOrderSelected;
			this.model.orderDeselected += this.onOrderDeselected;

			if(this.model.owner != null)
			{
				this.Flag.Fill = new SolidColorBrush(this.model.owner.color);
				this.WavingFlag.Begin();
				this.WavingFlag.RepeatBehavior = RepeatBehavior.Forever;
			}
			else
				this.FlagContainer.Visibility = Visibility.Collapsed;
		}

		public PlayableTile()
		{
			InitializeComponent();

			this.orderDecals = new MapTileOrderDecals();
			this.MouseEnter += this.onMouseEnter;
			this.MouseLeave += this.onMouseLeave;
		}
		
		public void onMouseEnter(object sender, MouseEventArgs e)
		{
			this.OverLayer.Visibility = Visibility.Visible;
		}

		public void onMouseLeave(object sender, MouseEventArgs e)
		{
			this.OverLayer.Visibility = Visibility.Collapsed;
		}

		public void onSelect(object sender, EventArgs e)
		{
			map.showTileMenu(this);
		}

		public void onDeselect(object sender, EventArgs e)
		{
			map.hideTileMenu();
		}

		private void onOrderAdded(object sender, OrderEventArgs e)
		{
			if(e.order.Type == "Defend")
			{
				this.orderDecals.DefendOrderContainer.Visibility = Visibility.Visible;
				this.orderDecals.DefendValue.Text = e.order.UnitCount.ToString();
			}
			else if(e.order.Type == "Buy")
			{
				this.orderDecals.BuyOrderContainer.Visibility = Visibility.Visible;
				this.orderDecals.BuyValue.Text = e.order.UnitCount.ToString();
			}
			else if(e.order.Type == "Move")
			{
				if(e.order.Source.x - e.order.Destination.x == 1)
				{
					this.orderDecals.LeftMoveOrderContainer.Visibility = Visibility.Visible;
					this.orderDecals.LeftMoveValue.Text = e.order.UnitCount.ToString();
				}
				else if(e.order.Source.x - e.order.Destination.x == -1)
				{
					this.orderDecals.RightMoveOrderContainer.Visibility = Visibility.Visible;
					this.orderDecals.RightMoveValue.Text = e.order.UnitCount.ToString();
				}
				else if(e.order.Source.y - e.order.Destination.y == 1)
				{
					this.orderDecals.UpMoveOrderContainer.Visibility = Visibility.Visible;
					this.orderDecals.UpMoveValue.Text = e.order.UnitCount.ToString();
				}
				else if(e.order.Source.y - e.order.Destination.y == -1)
				{
					this.orderDecals.DownMoveOrderContainer.Visibility = Visibility.Visible;
					this.orderDecals.DownMoveValue.Text = e.order.UnitCount.ToString();
				}
			}
		}

		private void onOrderRemoved(object sender, OrderEventArgs e)
		{
			if(e.order.Type == "Defend")
				this.orderDecals.DefendOrderContainer.Visibility = Visibility.Collapsed;
			else if(e.order.Type == "Buy")
				this.orderDecals.BuyOrderContainer.Visibility = Visibility.Collapsed;
			else if(e.order.Type == "Move")
			{
				if(e.order.Source.x - e.order.Destination.x == 1)
					this.orderDecals.LeftMoveOrderContainer.Visibility = Visibility.Collapsed;
				else if(e.order.Source.x - e.order.Destination.x == -1)
					this.orderDecals.RightMoveOrderContainer.Visibility = Visibility.Collapsed;
				else if(e.order.Source.y - e.order.Destination.y == 1)
					this.orderDecals.UpMoveOrderContainer.Visibility = Visibility.Collapsed;
				else if(e.order.Source.y - e.order.Destination.y == -1)
					this.orderDecals.DownMoveOrderContainer.Visibility = Visibility.Collapsed;
			}
		}

		private void onOrderSelected(object sender, OrderEventArgs e)
		{
			if(e.order.Type == "Defend")
				this.orderDecals.DefendOrderContainer.Opacity = 1;
			else if(e.order.Type == "Buy")
				this.orderDecals.BuyOrderContainer.Opacity = 1;
			else if(e.order.Type == "Move")
			{
				if(e.order.Source.x - e.order.Destination.x == 1)
					this.orderDecals.LeftMoveOrderContainer.Opacity = 1;
				else if(e.order.Source.x - e.order.Destination.x == -1)
					this.orderDecals.RightMoveOrderContainer.Opacity = 1;
				else if(e.order.Source.y - e.order.Destination.y == 1)
					this.orderDecals.UpMoveOrderContainer.Opacity = 1;
				else if(e.order.Source.y - e.order.Destination.y == -1)
					this.orderDecals.DownMoveOrderContainer.Opacity = 1;
			}
		}

		private void onOrderDeselected(object sender, OrderEventArgs e)
		{
			if(e.order.Type == "Defend")
				this.orderDecals.DefendOrderContainer.Opacity = 0.5;
			else if(e.order.Type == "Buy")
				this.orderDecals.BuyOrderContainer.Opacity = 0.5;
			else if(e.order.Type == "Move")
			{
				if(e.order.Source.x - e.order.Destination.x == 1)
					this.orderDecals.LeftMoveOrderContainer.Opacity = 0.5;
				else if(e.order.Source.x - e.order.Destination.x == -1)
					this.orderDecals.RightMoveOrderContainer.Opacity = 0.5;
				else if(e.order.Source.y - e.order.Destination.y == 1)
					this.orderDecals.UpMoveOrderContainer.Opacity = 0.5;
				else if(e.order.Source.y - e.order.Destination.y == -1)
					this.orderDecals.DownMoveOrderContainer.Opacity = 0.5;
			}
		}
	}
}
