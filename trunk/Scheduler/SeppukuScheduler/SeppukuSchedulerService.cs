using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;

namespace SeppukuScheduler
{
	public partial class SeppukuSchedulerService : ServiceBase
	{
		private Timer timer;

		public SeppukuSchedulerService()
		{
			InitializeComponent();
			//ScheduledTask();
			InitializeTimer();
		}

		private void ScheduledTask()
		{
			SeppukuWebService.SeppukuService objJob = new SeppukuWebService.SeppukuService();
			String retValue = objJob.UpdateGameState();
			//StreamWriter writer = new StreamWriter(new FileStream("log.log",FileMode.OpenOrCreate));
			//writer.WriteLine(retValue + " " + DateTime.Now);
			//writer.Flush();
			Console.WriteLine(retValue + " " + DateTime.Now);
		}

		private void InitializeTimer()
		{
			if (timer == null)
			{
				timer = new Timer();
				timer.AutoReset = true;
				timer.Interval = 60000 * Convert.ToDouble(1);
				timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
				timer.Start();
			}
		}

		private void timer_Elapsed(object source,System.Timers.ElapsedEventArgs e)
		{
		    ScheduledTask();
		}

		public void start(string[] args)
		{
			this.OnStart(args);
		}

		protected override void OnStart(string[] args)
		{
		}

		public void stop()
		{
			this.OnStop();
		}

		protected override void OnStop()
		{
		}
	}
}
