using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using SeppukuMap.Model;

namespace SeppukuMap
{
	public partial class ActionList : UserControl
	{
		private SeppukuMapTileModel tileModel;
		public SeppukuMapTileModel TileModel
		{
			get{
				return tileModel;
			}
			set{
				if(tileModel != null)
				{
					this.tileModel.workerDistributionChange -= this.onWorkerDistributionChange;
				}
				tileModel = value;
				if(this.tileModel != null)
				{
					this.PeopleCount.Text = tileModel.numberOfWorkers.ToString();
					this.tileModel.workerDistributionChange += this.onWorkerDistributionChange;
					this.Attackers.upperLimit = tileModel.Warriors;
					this.Warriors.upperLimit = tileModel.numberOfWorkers;
					this.Warriors.number = 0;
					this.Attackers.number = 0;
				}

				this.Warriors.myUpdate();
				this.Attackers.myUpdate();
			}
		}

		public ActionList()
		{
			// Required to initialize variables
			InitializeComponent();

			this.Warriors.changed += this.onGatherersChanged;
			//this.Attackers.changed += this.onAttackersChanged;
			this.AttackButton.Click += this.onAttackButtonClicked;
			this.MouseLeftButtonUp += this.onMouseClick;
		}

		private void onWorkerDistributionChange(object sender, EventArgs e)
		{
			this.Attackers.upperLimit = tileModel.Warriors;
			if(this.Attackers.number > this.Attackers.upperLimit)
				this.Attackers.number = this.Attackers.upperLimit;
			this.Warriors.number = tileModel.Gatherers;
			this.Warriors.myUpdate();
			this.Attackers.myUpdate();
		}

		private void onGatherersChanged(object sender, EventArgs e)
		{
			this.tileModel.Gatherers = this.Warriors.number;
		}

		private void onAttackButtonClicked(object sender, EventArgs e)
		{
			if(this.Attackers.number > 0)
			{
				this.tileModel.mapModel.DestinationTileFieldMode = true;
			}
		}

		/*private void onAttackersChanged(object sender, EventArgs e)
		{
			
		}*/

		private void onMouseClick(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}
	}
}