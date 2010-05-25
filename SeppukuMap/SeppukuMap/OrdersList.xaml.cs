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
			this.OrderList.IsSynchronizedWithCurrentItem = true;
		}
	}
}
