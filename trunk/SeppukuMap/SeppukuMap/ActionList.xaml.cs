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
					this.tileModel.workerDistributionChange += this.onWorkerDistributionChange;
					this.tileModel.mapModel.model.RiceNumberChanged += this.onRiceNumberChanged;

					this.PeopleCount.Text = tileModel.Gatherers.ToString();
					this.PeopleSelectSlider.upperLimit = tileModel.Gatherers;
					this.PeopleSelectSlider.Number = 0;
					this.PeopleSelectSlider.changed += this.onSliderChanged;

					this.RecruitSlider.upperLimit = this.tileModel.mapModel.model.RiceNumber / 100;
					this.RecruitSlider.Number = 0;
					this.RecruitSlider.changed += this.onSliderChanged;

					updatePanel();
				}
			}
		}

		public ActionList()
		{
			// Required to initialize variables
			InitializeComponent();

			this.AttackButton.Click += this.onAttackButtonClicked;
			this.DeffendButton.Click += this.onDeffendButtonClicked;
			this.RecruitButton.Click += this.onRecruitButtonClicked;
			this.MouseLeftButtonUp += this.onMouseClick;
		}

		private void updatePanel()
		{
			if(this.PeopleSelectSlider.Number == 0)
			{
				this.DeffendButton.IsEnabled = false;
				this.AttackButton.IsEnabled = false;
			}
			else
			{
				this.DeffendButton.IsEnabled = true;
				this.AttackButton.IsEnabled = true;
			}

			if(this.RecruitSlider.Number == 0)
				this.RecruitButton.IsEnabled = false;
			else
				this.RecruitButton.IsEnabled = true;
		}

		private void onWorkerDistributionChange(object sender, EventArgs e)
		{
			this.PeopleCount.Text = tileModel.Gatherers.ToString();
			this.PeopleSelectSlider.upperLimit = tileModel.Gatherers;
			this.PeopleSelectSlider.myUpdate();
		}

		private void onRiceNumberChanged(object sender, EventArgs e)
		{
			this.RecruitSlider.upperLimit = this.tileModel.mapModel.model.RiceNumber / 100;
		}

		private void onSliderChanged(object sender, EventArgs e)
		{
			updatePanel();
		}

		private void onAttackButtonClicked(object sender, EventArgs e)
		{
			if(this.PeopleSelectSlider.Number > 0)
			{
				this.tileModel.mapModel.SelectedPopulation = this.PeopleSelectSlider.Number;
				this.tileModel.mapModel.DestinationTileFieldMode = true;
			}
		}

		private void onDeffendButtonClicked(object sender, EventArgs e)
		{
			if(this.PeopleSelectSlider.Number > 0)
			{
				this.tileModel.mapModel.model.addOrder(new DeffendOrder(this.tileModel, this.PeopleSelectSlider.Number));
				this.PeopleSelectSlider.Number = 0;
			}
		}

		private void onRecruitButtonClicked(object sender, EventArgs e)
		{
			if(this.RecruitSlider.Number > 0)
			{
				this.tileModel.mapModel.model.addOrder(new BuyOrder(this.tileModel, this.RecruitSlider.Number));
				this.RecruitSlider.upperLimit = this.tileModel.mapModel.model.RiceNumber / 100;
				this.RecruitSlider.Number = 0;
			}
		}

		private void onMouseClick(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}
	}
}