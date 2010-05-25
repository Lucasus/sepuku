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

namespace SeppukuMap
{
	public partial class PlayableTile : UserControl
	{
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
	}
}
