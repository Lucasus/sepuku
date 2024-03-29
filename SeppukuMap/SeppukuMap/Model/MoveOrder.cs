﻿using System;
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
	public class MoveOrder : AbstractOrder
	{
		public MoveOrder(SeppukuMapTileModel source, SeppukuMapTileModel destination, int unitCount) : base("Move",source,destination,unitCount,0)
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
