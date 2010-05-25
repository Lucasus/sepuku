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
	public class SeppukuMapTileModel
	{
		public int x;
		public int y;
		public Player owner;
		public string name;
		public SeppukuMapModel mapModel;

		public int numberOfWorkers;
		private int gatherers;
		public int Gatherers{
			get{
				return gatherers;
			}
			set{
				gatherers = value;
				warriors = numberOfWorkers - gatherers;
				if(this.workerDistributionChange != null)
					workerDistributionChange(this, null);
			}
		}
		
		private int warriors;
		public int Warriors{
			get{
				return warriors;
			}
			set{
				numberOfWorkers = numberOfWorkers - (warriors - value);
				warriors = value;
			}

		}

		public event EventHandler select;
		public event EventHandler deselct;
		public event EventHandler workerDistributionChange;

		public SeppukuMapTileModel(SeppukuMapModel mapModel, int x, int y, Player owner, String name, int numberOfWorkers)
		{
			this.mapModel = mapModel;
			this.x = x;
			this.y = y;
			this.owner = owner;
			this.name = name;
			this.numberOfWorkers = numberOfWorkers;
			this.gatherers = numberOfWorkers;
			this.warriors = 0;
		}

		public void selected()
		{
			if(this.select != null)
				this.select(this, null);
		}
		
		public void deselected()
		{
			if(this.deselct != null)
				this.deselct(this, null);
		}
	}
}
