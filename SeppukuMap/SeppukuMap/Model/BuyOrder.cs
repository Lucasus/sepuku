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
	public class BuyOrder : AbstractOrder
	{
		public BuyOrder(SeppukuMapTileModel source, int count) : base("Buy", source, source, count, 100 * count)
		{
			
		}

		public override void doChanges(SeppukuModel model)
		{
			model.RiceNumber -= 100 * UnitCount;
			base.doChanges(model);
		}

		public override void undoChanges(SeppukuModel model)
		{
			model.RiceNumber += 100 * UnitCount;
			base.undoChanges(model);
		}
	}
}
