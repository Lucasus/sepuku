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

using System.Windows.Resources;
using System.Windows.Media.Imaging;

namespace SeppukuMap
{
	public partial class SeppukuMapScroll : UserControl
	{
		public enum ScrollDirections
		{
			up,
			down,
			left,
			right
		}

		private double scale = 1;
		public double ScrollSpeed{get;set;}
		private Storyboard scrollAnim;
		private SeppukuMapScroll.ScrollDirections currentDirection;

		public SeppukuMapScroll()
		{
			InitializeComponent();
			this.ScrollDown.MouseEnter += this.onScrollEnter;
			this.ScrollDown.MouseLeave += this.onScrollLeave;
			this.ScrollUp.MouseEnter += this.onScrollEnter;
			this.ScrollUp.MouseLeave += this.onScrollLeave;
			this.ScrollLeft.MouseEnter += this.onScrollEnter;
			this.ScrollLeft.MouseLeave += this.onScrollLeave;
			this.ScrollRight.MouseEnter += this.onScrollEnter;
			this.ScrollRight.MouseLeave += this.onScrollLeave;

			this.scrollAnim = new Storyboard();
			scrollAnim.Duration = new Duration(TimeSpan.FromMilliseconds(30));
			scrollAnim.Completed += this.onComplete;

			this.ZoomIn.MouseLeftButtonDown += this.onZoomIn;
			this.ZoomOut.MouseLeftButtonDown += this.onZoomOut;

			this.MapTiles.loadingFinished += this.onMapLoad;
		}

		private void onMapLoad(object sender, EventArgs e)
		{
			double newX = Canvas.GetLeft(this.MapTiles);
			double newY = Canvas.GetTop(this.MapTiles);

			this.updateView(newX, newY);
		}

		private void onComplete(object sender, EventArgs e)
		{
			moveTilesView(this.currentDirection, ScrollSpeed);
			Storyboard storyboard = (Storyboard) sender;
			storyboard.Begin();
		}

		private void onScrollEnter(object sender, MouseEventArgs e)
		{
			ScrollButton button = (ScrollButton) sender;
			button.Opacity = 1;
			this.currentDirection = button.Direction;
			scrollAnim.Begin();
		}

		private void onScrollLeave(object sender, MouseEventArgs e)
		{
			ScrollButton button = (ScrollButton) sender;
			button.Opacity = 0.5;
			scrollAnim.Stop();
		}

		public void onZoomIn(object sender, MouseButtonEventArgs e)
		{
			double newX = Canvas.GetLeft(this.MapTiles);
			double newY = Canvas.GetTop(this.MapTiles);

			if(scale + 0.1 < 1)
				scale += 0.1;
			else 
				scale = 1;

			this.updateView(newX, newY);
		}

		public void onZoomOut(object sender, MouseButtonEventArgs e)
		{
			double newX = Canvas.GetLeft(this.MapTiles);
			double newY = Canvas.GetTop(this.MapTiles);

			if(scale - 0.1 > 0.5)
				scale -= 0.1;
			else 
				scale = 0.3;

			this.updateView(newX, newY);
		}

		public void moveTilesView(SeppukuMapScroll.ScrollDirections direction, double offset)
		{
			double newX = Canvas.GetLeft(this.MapTiles);
			double newY = Canvas.GetTop(this.MapTiles);
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

		private void updateView(double x, double y)
		{
			if(this.MapTiles.DynamicWidth * scale < MapTilesView.Width)
				Canvas.SetLeft(this.MapTiles, (MapTilesView.Width - this.MapTiles.DynamicWidth * scale) * 0.5);
			else
			{
				if(x < MapTilesView.Width * 0.25 && x > MapTilesView.Width * 0.75 - this.MapTiles.DynamicWidth * scale)
					Canvas.SetLeft(this.MapTiles, x);
			}

			if(this.MapTiles.DynamicHeight * scale < MapTilesView.Height)
				Canvas.SetTop(this.MapTiles, (MapTilesView.Height - this.MapTiles.DynamicHeight * scale) * 0.5);
			else
			{
				if(y < MapTilesView.Height * 0.25 && y > MapTilesView.Height * 0.75 - this.MapTiles.DynamicHeight * scale)
					Canvas.SetTop(this.MapTiles, y);
			}

			ScaleTransform transform = new ScaleTransform();

			transform.ScaleX = transform.ScaleY = scale;
			this.MapTiles.RenderTransform = transform;
		}
	}
}
