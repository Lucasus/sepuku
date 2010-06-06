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
	public class GatherOrder : AbstractOrder
	{
		public GatherOrder(SeppukuMapTileModel source, int unitCount) : base("Gather", source, source, unitCount, 0)
		{
			
		}

		public override void doChanges(SeppukuModel model)
		{
			Source.Gatherers = Source.Gatherers - UnitCount;
			base.doChanges(model);
		}

		public override void undoChanges(SeppukuModel model)
		{
			Source.Gatherers = Source.Gatherers + UnitCount;
			base.undoChanges(model);
		}
	}
}
