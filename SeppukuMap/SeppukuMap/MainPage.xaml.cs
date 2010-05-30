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

using SeppukuMap.Events;
using SeppukuMap.Model;

namespace SeppukuMap
{
	public partial class MainPage : UserControl
	{
		//public String playerName;
		public SeppukuModel model;

		public MainPage()
		{
			InitializeComponent();
			
			this.MapWithScroll.MapTiles.tileOverEvent += this.updateInfo;
			this.MapWithScroll.MapTiles.tileOutEvent += this.clearInfo;
		}

		public MainPage(SeppukuModel model): this()
		{
			//this.playerName = playerName;
			this.MapWithScroll.MapTiles.initWithModel(model.map);
			this.OrdersList.initWithModel(model);
			this.KingdomPanel.initWithModel(model);
		}

		public void onReady(object sender, EventArgs e)
		{
			
			
		}

		public void updateInfo(object sender, TileEventArgs e)
		{
			InfoPanel.displayTile(e.tile.model);
		}

		public void clearInfo(object sender, TileEventArgs e)
		{
			InfoPanel.clearDisplay();
		}
	}
}
