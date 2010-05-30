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
using System.Collections.Generic;

using SeppukuMap.Events;
using SeppukuMap.SeppukuService;

namespace SeppukuMap.Model
{
	public class SeppukuMapModel
	{
		public ICollection<SeppukuMapTileModel> tiles;
		public SeppukuModel model;

		private bool destinationTileFieldMode;
		public bool DestinationTileFieldMode{
			get{
				return destinationTileFieldMode;
			}
			set{
				this.destinationTileFieldMode = value;
				if(this.destinationTileFieldMode == true)
				{
					if(this.destinationTileFieldModeSet != null)
						this.destinationTileFieldModeSet(this, null);
					Logger.getInstance().logs.Add("Select a Tile");
				}
			}
		}

		private int selectedPopulation;
		public int SelectedPopulation
		{
			get{
				return selectedPopulation;
			}
			set{
				this.selectedPopulation = value;
			}
		}

		private SeppukuMapTileModel tileSelected;
		public SeppukuMapTileModel TileSelected{
			get
			{
				return tileSelected;
			}
			set
			{
				if(this.tileSelected != null)
					this.tileSelected.deselected();
				this.tileSelected = value;
				if(this.tileSelected != null)
					this.tileSelected.selected();
			}
		}

		public event EventHandler destinationTileFieldModeSet;

		public SeppukuMapModel(SeppukuModel model, ICollection<TileInfo> tilesInfo)
		{
			this.model = model;
			this.destinationTileFieldMode = false;
			tiles = new List<SeppukuMapTileModel>();
			
			foreach(TileInfo info in tilesInfo)
			{
				Player player = null;
				if(info.ownerId != null)
				{
					if(model.players.ContainsKey((int)info.ownerId))
						player = model.players[(int)info.ownerId];
				}
				tiles.Add(new SeppukuMapTileModel(this, info.x, info.y, player, info.name, info.numberOfWorkers));
			}
		}

		public void tileAction(SeppukuMapTileModel model)
		{
			if(destinationTileFieldMode)
			{
				this.DestinationTileFieldMode = false;
				if(Math.Abs(model.x - tileSelected.x) + Math.Abs(model.y - tileSelected.y) == 1)
				{
					this.model.addOrder(new MoveOrder(this.tileSelected, model, SelectedPopulation));
				}
			}
			else
			{
				if(model.owner != null && model.owner.id == this.model.currentPlayerId)	
					this.TileSelected = model;
				else
					this.TileSelected = null;
			}
		}
	}
}
