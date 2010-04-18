using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.Globalization;


namespace SeppukuScheduler
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			SeppukuSchedulerService ServiceToRun = new SeppukuSchedulerService();

			if (Environment.UserInteractive)
			{
				while(Console.Read() != 'q')
				{

				}
			}
			else
			{
				ServiceBase.Run(ServiceToRun);
			}
		}
	}
}
