using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;

namespace WpfApp1
{
	public partial class MainWindow : Window
	{
		private Dictionary<string, string> dictionary = new Dictionary<string, string>();

		public MainWindow(string pathToJson)
		{
			InitializeComponent();
			InitDictionary();
			InitMainWindow();

			PageObjectModel window = ReadFromJson<PageObjectModel>(pathToJson);

			Grid mainGrid = CreatePageObjectTree(window);

			Content = DataManager.getInstance().mainGrid;

			SizeToContent = SizeToContent.WidthAndHeight;

			
			//Style = (Style)FindResource("styleA");


		}

		private void InitMainWindow()
        {
			DataManager dataManager = DataManager.getInstance();
			
			dataManager.rowInFBG = 0;
			dataManager.colInFBG = 0;
			dataManager.menuFontSize = DataManager.random.Next(10, 15);
			dataManager.statusBarFontSize = DataManager.random.Next(10, 15);
		}

		private Grid CreatePageObjectTree(PageObjectModel window)
		{
			if (window != null)
			{
				CreatePageObjectTreeRecursion(window);
				InitTree(window, null);
			}

			return DataManager.getInstance().mainGrid;
		}

		private void CreatePageObjectTreeRecursion(PageObjectModel pageObjectModel)
		{
			string className;
			dictionary.TryGetValue(pageObjectModel._name, out className);

			pageObjectModel.pageObject = Activator.CreateInstance(typeof(MainWindow).Assembly.GetName().FullName, className).Unwrap() as PageObject;    
			
            if (pageObjectModel._children != null)
			{
				for (int i = 0; i < pageObjectModel._children.Length; ++i)
				{
					CreatePageObjectTreeRecursion(pageObjectModel._children[i]);
				}
			}	
		}

		private void InitTree(PageObjectModel pageObjectModel, ContainerPageObject container)
        {
			if (container != null && pageObjectModel.pageObject.element != null)
            {
				container.AddElement(pageObjectModel.pageObject);
            }

			container = pageObjectModel.pageObject as ContainerPageObject;


			if (pageObjectModel._children != null)
			{
				for (int i = 0; i < pageObjectModel._children.Length; ++i)
				{
					InitTree(pageObjectModel._children[i], container);
				}
			}
		}

		private T ReadFromJson<T>(string path)
		{
			string json = "";
			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					json = sr.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.Message.ToString());
			}

			return JsonConvert.DeserializeObject<T>(json);
		}

		private void InitDictionary()
        {
			dictionary.Add("Window", "WpfApp1.WindowContainerPageObject");
			dictionary.Add("StatusBar", "WpfApp1.StatusBarPO");
			dictionary.Add("Table", "WpfApp1.TablePO");
			dictionary.Add("TextArea", "WpfApp1.TextAreaPO");
			dictionary.Add("TreeView", "WpfApp1.TreeViewPO");
			dictionary.Add("List", "WpfApp1.ListPO");
			dictionary.Add("Tab", "WpfApp1.TabPO");
			dictionary.Add("GroupBox", "WpfApp1.GroupBoxPO");
			dictionary.Add("LineEditComboboxFormBox", "WpfApp1.FormBoxPO");
			dictionary.Add("RadioButtonBox", "WpfApp1.RadioButtonBoxPO");
			dictionary.Add("CheckboxBox", "WpfApp1.CheckboxBoxPO");
			dictionary.Add("Button", "WpfApp1.ButtonPO");
			dictionary.Add("LineEdit", "WpfApp1.LineEditPO");
			dictionary.Add("LabeledComboBox", "WpfApp1.LabelComboBoxPO");
			dictionary.Add("LabeledLineEdit", "WpfApp1.LabelLineEditPO");
			dictionary.Add("LabeledCheckbox", "WpfApp1.LabelCheckboxPO"); 
			dictionary.Add("ReversedLabeledCheckbox", "WpfApp1.ReversedLabelCheckboxPO");
			dictionary.Add("LabeledRadioButton", "WpfApp1.LabelRadioButtonPO");
			dictionary.Add("ReversedLabeledRadioButton", "WpfApp1.ReversedLabelRadioButtonPO");
			dictionary.Add("MenuItem", "WpfApp1.MenuItemPO");
			dictionary.Add("TabBar", "WpfApp1.TabBarPO");
			dictionary.Add("TableBox", "WpfApp1.TableBoxPO");
			dictionary.Add("TreeViewBox", "WpfApp1.TreeViewBoxPO");
			dictionary.Add("ListBox", "WpfApp1.ListBoxPO");
			dictionary.Add("TextAreaBox", "WpfApp1.TextAreaBoxPO");
		}


	}
}
