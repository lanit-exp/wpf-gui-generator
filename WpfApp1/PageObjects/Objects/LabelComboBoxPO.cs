using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class LabelComboBoxPO : PageObject
    {
        public override UIElement Make()
        {
			Grid gridForLabelComboBox = new Grid
			{
				Margin = new Thickness(5, 5, 5, 5),
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center
			};

			gridForLabelComboBox.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			gridForLabelComboBox.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			Label label = new Label
			{
				Content = new TextBlock { Text = DataManager.getInstance().RandomString(7, 15) },
				FontSize = DataManager.random.Next(10, 15)
			};
			Grid.SetColumn(label, 0);

			ComboBox comboBox = new ComboBox
			{
				MinWidth = DataManager.random.Next(70, 200),
				MinHeight = DataManager.random.Next(20, 30)
			};
			//ComboBoxItem comboBoxItem = new ComboBoxItem { Content = new TextBlock { Text = dataManager.RandomString(7, 10) } };
			//comboBox.ItemsSource = new List<ComboBoxItem>() { comboBoxItem };
			//comboBox.SelectedItem = comboBoxItem;


			Grid.SetColumn(comboBox, 1);

			gridForLabelComboBox.Children.Add(label);
			gridForLabelComboBox.Children.Add(comboBox);

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ gridForLabelComboBox, PageObjectEnum.LabeledComboBox },
				{ (TextBlock)label.Content, PageObjectEnum.Label },
				{ comboBox, PageObjectEnum.ComboBox }
			});

			return gridForLabelComboBox;
		}
    }
}
