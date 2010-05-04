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
		public double ScrollSpeed{get;set;}
		private bool zoomed;
		private Storyboard scrollAnim;
		private SeppukuMapTiles.ScrollDirections currentDirection;

		public SeppukuMapScroll()
		{
			InitializeComponent();
			zoomed = true;
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

			this.Zoom.MouseLeftButtonDown += this.onZoom;
		}

		private void onComplete(object sender, EventArgs e)
		{
			this.MapTiles.moveTilesView(this.currentDirection, ScrollSpeed);
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

		public void onZoom(object sender, MouseButtonEventArgs e)
		{
			SeppukuMapTiles mapTiles = this.MapTiles;
			if(this.zoomed)
			{
				mapTiles.ZoomTilesView(0.5);
			}
			else
			{
				mapTiles.ZoomTilesView(1);
			}
			this.zoomed = !this.zoomed;
		}
	}
}
