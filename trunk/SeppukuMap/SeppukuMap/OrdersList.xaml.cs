using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using SeppukuMap.Model;

namespace SeppukuMap
{
	public partial class OrdersList : UserControl
	{
		private SeppukuModel model;

		public OrdersList()
		{
			InitializeComponent();
		}
		
		public void initWithModel(SeppukuModel model)
		{
			this.model = model;
			this.OrderList.ItemsSource = model.Orders;
		}

		private void onDeleteOrderClicked(object sender, System.Windows.RoutedEventArgs e)
		{
			Button b = sender as Button;
			AbstractOrder data = b.DataContext as AbstractOrder;
			data.Source.mapModel.model.removeOrder(data);
			// TODO: Add event handler implementation here.
		}

		private void SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			 //order = (IOrder)this.OrderList.SelectedItem;

			foreach(object order in e.RemovedItems)
			{
				IOrder newOrder = (IOrder)order;
				newOrder.Source.deselectOrder(newOrder);
			}
			foreach(object order in e.AddedItems)
			{
				IOrder newOrder = (IOrder)order;
				newOrder.Source.selectOrder(newOrder);
			}
			// TODO: Add event handler implementation here.
		}
	}
}
