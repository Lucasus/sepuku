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

using System.ComponentModel;

namespace SeppukuMap.Model
{
	public interface IOrder
	{
		SeppukuMapTileModel Destination{get;}
		SeppukuMapTileModel Source{get;}
		int UnitCount{get;}
		String Type{get;}

		void join(IOrder order);

		void doChanges(SeppukuModel model);
		void undoChanges(SeppukuModel model);
	}
}
