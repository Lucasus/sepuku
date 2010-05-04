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

namespace SeppukuMap
{
	public partial class MainPage : UserControl
	{
		public String playerName;

		public MainPage()
		{
			InitializeComponent();
			this.MapWithScroll.MapTiles.tileOverEvent += this.updateInfo;
			this.MapWithScroll.MapTiles.tileOutEvent += this.clearInfo;
		}

		public MainPage(String playerName): this()
		{
			this.playerName = playerName;
		}

		public void updateInfo(object sender, TileEventArgs e)
		{
			InfoPanel.displayTile(e.tile);
		}

		public void clearInfo(object sender, TileEventArgs e)
		{
			InfoPanel.clearDisplay();
		}
	}
}
