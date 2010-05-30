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

using SeppukuMap.Model;

namespace SeppukuMap.Events
{
	public class OrderEventArgs : EventArgs
	{
		public IOrder order;

		public OrderEventArgs(IOrder order)
		{
			this.order = order;
		}
	}
}
