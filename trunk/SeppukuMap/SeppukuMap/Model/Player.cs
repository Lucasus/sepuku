using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SeppukuMap.Model
{
	public class Player
	{
		public string name;
		public Color color;
		public int id;

		public Player(string name, string color, int id)
		{
			this.name = name;
			this.color = Color.FromArgb(255,Convert.ToByte(color.Substring(1,2),16),Convert.ToByte(color.Substring(3,2),16),Convert.ToByte(color.Substring(5,2),16));
			this.id = id;
		}
	}
}
