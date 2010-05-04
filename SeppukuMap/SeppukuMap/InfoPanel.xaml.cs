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
	public partial class InfoPanel : UserControl
	{
		public InfoPanel()
		{
			InitializeComponent();
		}

		public void displayTile(PlayableTile tile)
		{
			TextBox.Text = tile.TileName;
		}

		public void clearDisplay()
		{
			TextBox.Text = "";
		}
	}
}
