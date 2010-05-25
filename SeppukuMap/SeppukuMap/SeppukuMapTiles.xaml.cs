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
using SeppukuMap.SeppukuService;

namespace SeppukuMap
{
	public partial class SeppukuMapTiles : UserControl
	{
		public delegate void TileEventHandler(object sender, TileEventArgs e);
		public event TileEventHandler tileOverEvent;
		public event TileEventHandler tileOutEvent;

		public event EventHandler loadingFinished;

		public SeppukuMapModel model;

		private ActionList actionList;
		
		private int loadedTilesX;
		private int loadedTilesY;

		private double dynamicWidth;
		public double DynamicWidth
		{
			get{
				return dynamicWidth;
			}
		}

		private double dynamicHeight;
		public double DynamicHeight
		{
			get{
				return dynamicHeight;
			}
		}

		public SeppukuMapTiles()
		{
			InitializeComponent();
			this.actionList = new ActionList();
			this.PopupWindows.Children.Add(actionList);
			this.actionList.Visibility = Visibility.Collapsed;
			this.MouseLeftButtonUp += this.onMapClicked;
		}

		public void initWithModel(SeppukuMapModel model)
		{
			this.model = model;
			this.model.destinationTileFieldModeSet += this.onSelectDestinationStateSet;

			int tileWidth = 101;
			int tileHeight = 82;
			int tileBaseHeight = 45;

			int minX = model.tiles.Min(tileInfo => tileInfo.x);
			int maxX = model.tiles.Max(tileInfo => tileInfo.x);
			int minY = model.tiles.Min(tileInfo => tileInfo.y);
			int maxY = model.tiles.Max(tileInfo => tileInfo.y);

			loadedTilesX = maxX - minX + 1 + 2;
			loadedTilesY = maxY - minY + 1 + 2;
		
			for(int i = 0; i <= maxY - minY + 2; i++)
			{
				for(int j = 0; j <= maxX - minX + 2; j++)
				{
					UserControl tile;

					if(model.tiles.Any(tileInfo => (tileInfo.x == j && tileInfo.y == i)))
					{
						SeppukuMapTileModel tileModel = model.tiles.First(tileInfo => (tileInfo.x == j && tileInfo.y == i));

						PlayableTile tempTile = new PlayableTile(this, tileModel);
						tempTile.TileName = tileModel.name;
						tile = tempTile;
						tile.MouseEnter += this.onTileOver;
						tile.MouseLeave += this.onTileOut;
						tile.MouseLeftButtonUp += this.onTileClicked;
					}
					else
						tile = new Tile();

					Canvas.SetLeft(tile, j * tileWidth);
					Canvas.SetTop(tile, i * tileHeight);

					if((j + 1) * tileWidth > this.dynamicWidth)
						this.dynamicWidth = (j + 1) * tileWidth;
					
					if((i + 1) * tileHeight + tileBaseHeight > this.dynamicHeight)
						this.dynamicHeight = (i + 1) * tileHeight + tileBaseHeight;

					this.Tiles.Children.Add(tile);
				}
			}

			this.UpdateLayout();

			if(this.loadingFinished != null)
				this.loadingFinished(this, null);
		}

		private void onTileOver(object sender, MouseEventArgs e)
		{
			if(tileOverEvent != null)
				tileOverEvent(this, new TileEventArgs((PlayableTile) sender));
		}

		private void onTileOut(object sender, MouseEventArgs e)
		{
			if(tileOutEvent != null)
				tileOutEvent(this, new TileEventArgs((PlayableTile) sender));
		}

		private void onSelectDestinationStateSet(object sender, EventArgs e)
		{
			this.actionList.Visibility = Visibility.Collapsed;
		}

		public void hideTileMenu()
		{
			this.actionList.Visibility = Visibility.Collapsed;
		}

		public void showTileMenu(PlayableTile tile)
		{
			this.actionList.Visibility = Visibility.Visible;
			Canvas.SetLeft(actionList, Canvas.GetLeft(tile) + tile.Width);
			Canvas.SetTop(actionList, Canvas.GetTop(tile));
			this.actionList.TileModel = tile.model;
		}

		private void onTileClicked(object sender, MouseButtonEventArgs e)
		{
			this.model.tileAction(((PlayableTile)sender).model);
			e.Handled = true;
		}

		private void onMapClicked(object sender, MouseButtonEventArgs e)
		{
			this.model.DestinationTileFieldMode = false;
			this.hideTileMenu();
		}
	}
}
