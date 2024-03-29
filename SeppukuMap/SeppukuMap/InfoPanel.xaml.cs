﻿using System;
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

namespace SeppukuMap
{
	public partial class InfoPanel : UserControl
	{
		public InfoPanel()
		{
			InitializeComponent();
		}

		public void displayTile(SeppukuMapTileModel tile)
		{
			TileName.Text = tile.name;
			TileNameContainer.Visibility = Visibility.Visible;
			if(tile.owner != null)
			{
				PlayerName.Text = tile.owner.name;
				PlayerNameContainer.Visibility = Visibility.Visible;
			}
			Workers.Text = tile.Gatherers.ToString();
			WorkersContainer.Visibility = Visibility.Visible;
		}

		public void clearDisplay()
		{
			TileName.Text = "";
			TileNameContainer.Visibility = Visibility.Collapsed;
			PlayerName.Text = "";
			PlayerNameContainer.Visibility = Visibility.Collapsed;
			Workers.Text = "";
			WorkersContainer.Visibility = Visibility.Collapsed;
		}
	}
}
