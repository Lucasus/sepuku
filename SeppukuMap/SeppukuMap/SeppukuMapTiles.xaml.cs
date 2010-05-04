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
using SeppukuMap.SeppukuService;

namespace SeppukuMap
{
	public partial class SeppukuMapTiles : UserControl
	{
		public delegate void TileEventHandler(object sender, TileEventArgs e);
		public event TileEventHandler tileOverEvent;
		public event TileEventHandler tileOutEvent;

		private int loadedTilesX;
		private int loadedTilesY;
		private int tileWidth;
		private int tileHeight;
		private int tileBaseHeight;
		private double scale = 1;

		public enum ScrollDirections
		{
			up,
			down,
			left,
			right
		}

		public SeppukuMapTiles()
		{
			InitializeComponent();

			tileWidth = 101;
			tileHeight = 82;
			tileBaseHeight = 45;

			SeppukuServiceSoapClient client = new SeppukuServiceSoapClient();
			client.GetTilesCompleted += this.onMapLoad;
			client.GetTilesAsync();
		}

		public void onMapLoad(object sender, GetTilesCompletedEventArgs e)
		{
			createMap((ICollection<TileInfo>) e.Result);
		}

		public void moveTilesView(SeppukuMapTiles.ScrollDirections direction, double offset)
		{
			double newX = Canvas.GetLeft(this.Tiles);
			double newY = Canvas.GetTop(this.Tiles);
			switch(direction)
			{
				case ScrollDirections.up:
					{
						newY += offset;
						break;
					}
				case ScrollDirections.down:
					{
						newY -= offset;
						break;
					}
				case ScrollDirections.left:
					{
						newX += offset;
						break;
					}
				case ScrollDirections.right:
					{
						newX -= offset;
						break;
					}
			}

			updateView(newX, newY);
		}

		public void ZoomTilesView(double newZoom)
		{
			double newX = Canvas.GetLeft(this.Tiles);
			double newY = Canvas.GetTop(this.Tiles);
			scale = newZoom;
			updateView(newX, newY);
		}

		private void updateView(double x, double y)
		{
			if(loadedTilesX * tileWidth * scale < this.Width)
				Canvas.SetLeft(this.Tiles, (this.Width - loadedTilesX * tileWidth * scale) / 2);
			else
			{
				if(x <= 0 && Math.Abs(x) <= this.loadedTilesX * tileWidth * scale - this.Width)
					Canvas.SetLeft(this.Tiles, x);
				else if( x > 0)
					Canvas.SetLeft(this.Tiles, 0);
				else
					Canvas.SetLeft(this.Tiles,  -(this.loadedTilesX * tileWidth * scale - this.Width));
			}


			if((loadedTilesY * tileHeight + tileBaseHeight) * scale < this.Height)
				Canvas.SetTop(this.Tiles, (this.Height - (loadedTilesY * tileHeight + tileBaseHeight) * scale) / 2);
			else
			{
				if(y <= 0 && Math.Abs(y) <= (this.loadedTilesY * tileHeight + tileBaseHeight) * scale - this.Height)
					Canvas.SetTop(this.Tiles, y);
				else if( y > 0)
					Canvas.SetTop(this.Tiles, 0);
				else
					Canvas.SetTop(this.Tiles, -((this.loadedTilesY * tileHeight + tileBaseHeight) * scale - this.Height));
			}

			ScaleTransform transform = new ScaleTransform();
			transform.ScaleX = transform.ScaleY = scale;
			this.Tiles.RenderTransform = transform;
		}

		private void createMap(ICollection<TileInfo> collection)
		{
			int minX = collection.Min(tileInfo => tileInfo.x);
			int maxX = collection.Max(tileInfo => tileInfo.x);
			int minY = collection.Min(tileInfo => tileInfo.y);
			int maxY = collection.Max(tileInfo => tileInfo.y);

			loadedTilesX = maxX - minX + 1 + 2;
			loadedTilesY = maxY - minY + 1 + 2;
		
			for(int i = minY - 1; i <= maxY + 1; i++)
			{
				for(int j = minX - 1; j <= maxX + 1; j++)
				{
					UIElement tile;
					
					if(collection.Any(tileInfo => (tileInfo.x == j && tileInfo.y == i)))
					{
						TileInfo info = collection.First(tileInfo => (tileInfo.x == j && tileInfo.y == i));
						PlayableTile tempTile = new PlayableTile();
						tempTile.TileName = info.name;
						tile = tempTile;
						tile.MouseEnter += this.tileOver;
						tile.MouseLeave += this.tileOut;
					}
					else
						tile = new Tile();
					Canvas.SetLeft(tile, j * tileWidth);
					Canvas.SetTop(tile, i * tileHeight);

					this.Tiles.Children.Add(tile);
				}
			}

			this.UpdateLayout();

			this.updateView(loadedTilesX, loadedTilesY);
		}

		private void tileOver(object sender, MouseEventArgs e)
		{
			if(tileOverEvent != null)
				tileOverEvent(this, new TileEventArgs((PlayableTile) sender));
		}

		private void tileOut(object sender, MouseEventArgs e)
		{
			if(tileOutEvent != null)
				tileOutEvent(this, new TileEventArgs((PlayableTile) sender));
		}
	}
}
