using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Specialized;

using SeppukuMap.Model;

namespace SeppukuMap
{
	public partial class StatusBar : UserControl
	{
		public StatusBar()
		{
			// Required to initialize variables
			InitializeComponent();

			Logger logger = Logger.getInstance();
			logger.logs.CollectionChanged += new NotifyCollectionChangedEventHandler(logsChanged);
		}

		void logsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.LogBox.Text = Logger.getInstance().logs[Logger.getInstance().logs.Count - 1];
			throw new NotImplementedException();
		}
	}
}