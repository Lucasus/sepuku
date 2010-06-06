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

using System.Windows.Resources;
using System.Windows.Media.Imaging; 

using System.ComponentModel;

using SeppukuMap.SeppukuService;

namespace SeppukuMap.Model
{
	public abstract class AbstractOrder : IOrder, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int unitCount;
		public int UnitCount{
			get{
				return unitCount;
			}
			set{
				this.unitCount = value;
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("UnitCount"));
			}
		}
	
		private SeppukuMapTileModel source;
		public SeppukuMapTileModel Source{
			get{
				return source;
			}
			set{
				this.source = value;
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Source"));
			}
		}
		private SeppukuMapTileModel destination;
		public SeppukuMapTileModel Destination{
			get{
				return destination;
			}
			set{
				this.destination = value;
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Destination"));
			}
		}

		private String type;
		public String Type{
			get{
				return type;
			}
			set{
				type = value;
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Type"));
			}
		}

		private int orderCost;
		public int OrderCost{
			get{
				return this.orderCost;
			}
			set{
				this.orderCost = value;
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("OrderCost"));
			}

		}

		private String image;
		public String Image{
			get{
				return this.image;
			}
			set{
				this.image = value;
				if(PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("ImageString"));
			}
		}
		
		public String SourceName{
			get{
				return this.Source.name;
			}
		}

		public String DestinationName{
			get{
				return this.Destination.name;
			}
		}

		public AbstractOrder(String type, SeppukuMapTileModel source, SeppukuMapTileModel destination, int unitCount, int cost)
		{
			this.Type = type;
			if(type == "Defend")
			{
				this.Image = "Resources/Shield.png";
			}
			else if(type == "Move")
			{
				this.Image = "Resources/Leg.png";
			}
			else if(type == "Buy")
			{
				this.Image = "Resources/money.png";
			}
			else if(type == "Gather")
			{
				this.Image = "Resources/gather.png";
			}
			

			this.Source = source;
			this.Destination = destination;
			this.UnitCount = unitCount;
			this.orderCost = cost;
		}

		public virtual void doChanges(SeppukuModel model)
		{
			SeppukuServiceSoapClient client = new SeppukuServiceSoapClient();
			OrderInfo info = new OrderInfo();
			info.orderType = this.Type;
			info.sourceTileId = this.Source.tileId;
			info.destinationTileId = this.Destination.tileId;
			info.unitCount = this.UnitCount;
			client.addOrderAsync(info);
		}

		public virtual void undoChanges(SeppukuModel model)
		{
			SeppukuServiceSoapClient client = new SeppukuServiceSoapClient();
			OrderInfo info = new OrderInfo();
			info.orderType = this.Type;
			info.sourceTileId = this.Source.tileId;
			info.destinationTileId = this.Destination.tileId;
			info.unitCount = this.UnitCount;
			client.removeOrderAsync(info);
		}

		public void join(IOrder order)
		{
			if(order.Type == this.type && order.Source == this.Source && order.Destination == this.Destination)
			{
				AbstractOrder otherOrder = (AbstractOrder)order;
				this.UnitCount += otherOrder.UnitCount;
			}
		}
	}
}
