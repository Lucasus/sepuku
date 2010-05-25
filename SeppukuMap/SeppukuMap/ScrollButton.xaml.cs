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
	public partial class ScrollButton : UserControl
	{
		private SeppukuMapScroll.ScrollDirections direction;
		public SeppukuMapScroll.ScrollDirections Direction
		{
			get{return direction;}
			set{direction = value;}
		}

		public ScrollButton()
		{
			InitializeComponent();
		}
	}
}
