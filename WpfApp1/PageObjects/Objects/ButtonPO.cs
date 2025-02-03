using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class ButtonPO : PageObject
    {
        public override UIElement Make()
        {
			Grid gridButton = new Grid
			{
				Margin = new Thickness(5, 5, 5, 5),
				MinHeight = DataManager.random.Next(20, 50)
			};

			gridButton.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			gridButton.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			Button button = new Button { 
				Content = DataManager.getInstance().RandomString(7, 15), 
				MaxWidth = 100, 
				MinWidth = DataManager.random.Next(70, 200), 
				FontSize = DataManager.random.Next(10, 15) 
			};

			Grid.SetColumn(button, 1);
			gridButton.Children.Add(button);


			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ button, PageObjectEnum.Button }
			});

            return gridButton;
		}
    }
}
