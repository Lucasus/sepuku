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
	public class MoveOrder : IOrder
	{
		private SeppukuMapTileModel source;
		private SeppukuMapTileModel destination;
		private int unitCount;

		public string OrderDisplay;

		public MoveOrder(SeppukuMapTileModel source, SeppukuMapTileModel destination, int unitCount)
		{
			this.source = source;
			this.destination = destination;
			this.unitCount = unitCount;
			this.OrderDisplay = "Moose Master";
		}

		public void doChanges()
		{
			source.Warriors -= unitCount;
		}

		public void undoChanges()
		{
			source.Warriors += unitCount;
		}

		public string getSignature()
		{
			return this.OrderDisplay;
		}
	}
}
