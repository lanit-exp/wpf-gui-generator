using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
	class ReversedLabelRadioButtonPO : PageObject
	{
		public override UIElement Make()
        {
			Grid gridForLabelComboBox = new Grid
			{
				Margin = new Thickness(5, 5, 5, 5),
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center
			};

			gridForLabelComboBox.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
			gridForLabelComboBox.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

			RadioButton radioButton = new RadioButton
			{
				Margin = new Thickness(0, 5, 0, 5)
			};
			Grid.SetColumn(radioButton, 0);

			Label label = new Label
			{
				Content = new TextBlock { Text = DataManager.getInstance().RandomString(7, 15) },
				FontSize = DataManager.random.Next(10, 15),
			};
			Grid.SetColumn(label, 1);


			gridForLabelComboBox.Children.Add(radioButton);
			gridForLabelComboBox.Children.Add(label);

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ gridForLabelComboBox, PageObjectEnum.ReversedLabeledRadioButton },
				{ (TextBlock)label.Content, PageObjectEnum.Label },
				{ radioButton, PageObjectEnum.RadioButton },

			});


			return gridForLabelComboBox;
		}
	}
}
