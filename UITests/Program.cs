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
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;

namespace UITests
{
	internal class Program
	{
		private static void Main (string[] args)
		{

			Application application = Application.Launch("..\\..\\..\\WPF DataGrid\\bin\\Debug\\WPF.exe");
			Window window = application.GetWindow("MainWindow", InitializeOption.NoCache);

			window.Get<ListView>("Grid").RightClick();
			PopUpMenu popupMenu = window.Popup;
			Menu level2Menu = popupMenu.Item("First", "InternalFirst");
//			level2Menu = popupMenu.ItemBy(SearchCriteria.ByText("First"), SearchCriteria.ByText("InternalFirst"));
			level2Menu.Click();

			//			ListView grid = window.Get<ListView>("Grid");
			//			var listItem = (WPFListItem)  grid.Get(SearchCriteria.ByText("Green"));
			//			var textBox = listItem.Get<TextBox>(SearchCriteria.All);
			//			textBox.Text = "Tested";
						application.Close();
		}

		

	}
}