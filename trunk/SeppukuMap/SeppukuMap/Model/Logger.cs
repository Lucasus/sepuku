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
using System.Collections.ObjectModel;

namespace SeppukuMap.Model
{
	public class Logger
	{
		public ObservableCollection<String> logs;

		private static Logger instance;

		private Logger()
		{
			logs = new ObservableCollection<String>();
		}

		public static Logger getInstance()
		{
			if(instance == null)
			{
				instance = new Logger();
			}
			return instance;
		}
	}
}
