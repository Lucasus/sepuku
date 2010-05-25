using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SeppukuMap
{
	public partial class NumberPicker : UserControl
	{
		public int upperLimit;
		public int lowerLimit;
		public int number;

		public event EventHandler changed;

		public NumberPicker()
		{
			// Required to initialize variables
			InitializeComponent();
			this.AddButton.Click += this.onAddClicked;
			this.RemoveButton.Click += this.onRemoveClicked;
		}

		public void onAddClicked(object sender, EventArgs e)
		{
			if(this.number + 1 <= upperLimit)
			{
				this.number += 1;
				this.myUpdate();
				if(this.changed != null)
					this.changed(this, null);
			}
		}
		 
		public void onRemoveClicked(object sender, EventArgs e)
		{
			if(this.number - 1 >= lowerLimit)
			{
				this.number -= 1;
				this.myUpdate();
				if(this.changed != null)
					this.changed(this, null);
			}
		}

		public void myUpdate()
		{
			this.numberValue.Text = this.number.ToString();// + "/" + this.upperLimit.ToString();
		}
	}
}