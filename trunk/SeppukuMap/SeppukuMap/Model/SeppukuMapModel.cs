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


		public event EventHandler Ready;
		public event EventHandler destinationTileFieldModeSet;

		public SeppukuMapModel(SeppukuModel model)
		{
			this.model = model;
			this.destinationTileFieldMode = false;
			tiles = new List<SeppukuMapTileModel>();
			SeppukuServiceSoapClient client = new SeppukuServiceSoapClient();
			client.GetTilesCompleted += this.onMapLoad;
			client.GetTilesAsync();
		}
		public void onMapLoad(object sender, GetTilesCompletedEventArgs e)
		{
			ICollection<TileInfo> tilesInfo = (ICollection<TileInfo>) e.Result;
			
			foreach(TileInfo info in tilesInfo)
			{
				Player player = null;
				if(info.owner != null)
				{
					if(model.players.ContainsKey(info.owner.playerId))
						player = model.players[info.owner.playerId];
					else
					{
						player = new Player(info.owner.playerName, info.owner.playerColor, info.owner.playerId);
						model.players[info.owner.playerId] = player;
					}
				}
				tiles.Add(new SeppukuMapTileModel(this, info.x, info.y, player, info.name, info.numberOfWorkers));
			}

			if(this.Ready != null)
				this.Ready(this, null);
		}

		public void tileAction(SeppukuMapTileModel model)
		{
			if(destinationTileFieldMode)
			{
				this.DestinationTileFieldMode = false;
				if(Math.Abs(model.x - tileSelected.x) + Math.Abs(model.y - tileSelected.y) == 1)
				{
					this.model.addOrder(new MoveOrder(this.tileSelected, model, 5));
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
