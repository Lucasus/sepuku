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

		public AbstractOrder(String type, SeppukuMapTileModel source, SeppukuMapTileModel destination, int unitCount)
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
			

			this.Source = source;
			this.Destination = destination;
			this.UnitCount = unitCount;
		}

		public abstract void doChanges(SeppukuModel model);

		public abstract void undoChanges(SeppukuModel model);

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
