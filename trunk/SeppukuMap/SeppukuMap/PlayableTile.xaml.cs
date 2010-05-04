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

namespace SeppukuMap
{
	public partial class PlayableTile : UserControl
	{
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
	}
}
