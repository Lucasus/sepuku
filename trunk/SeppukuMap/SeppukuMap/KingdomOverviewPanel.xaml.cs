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
	public partial class KingdomOverviewPanel : UserControl
	{
		private SeppukuModel model;

		public KingdomOverviewPanel()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		public void initWithModel(SeppukuModel model)
		{
			this.model = model;
			
			int tileNumber = 0;
			int manCount = 0;
			foreach(SeppukuMapTileModel tileModel in model.map.tiles)
			{
				if(tileModel.owner != null && tileModel.owner.id == model.currentPlayerId)
				{
					tileNumber++;
					manCount += tileModel.Gatherers;
				}
			}
			
			this.PlayerFlag.Fill = new SolidColorBrush(this.model.players[this.model.currentPlayerId].color);

			this.TileNumber.Text = tileNumber.ToString();
			this.ManNumber.Text = manCount.ToString();
			this.RiceNumber.Text = model.RiceNumber.ToString();
			this.model.RiceNumberChanged += this.onRiceNumberChanged;
		}

		public void onRiceNumberChanged(object sender, EventArgs e)
		{
			this.RiceNumber.Text = this.model.RiceNumber.ToString();
		}
	}
}