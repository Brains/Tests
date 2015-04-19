using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace UITests
{
	internal class Program
	{
		private static void Main (string[] args)
		{

			Application application = Application.Launch("..\\..\\..\\WPF\\bin\\Debug\\WPF.exe");
			Window window = application.GetWindow("MainWindow", InitializeOption.NoCache);

			Button button = window.Get<Button>("TestButton");
			button.Click();

			TextBox text = window.Get<TextBox>("TestTextBox");
			Console.WriteLine(text.Text);

			application.Close();
		}

		

	}
}