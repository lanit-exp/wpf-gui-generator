using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class LabelCheckboxPO : PageObject
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

			Label label = new Label
			{
				Content = new TextBlock { Text = DataManager.getInstance().RandomString(7, 15) },
				FontSize = DataManager.random.Next(10, 15),
				Width = double.NaN
			};
			Grid.SetColumn(label, 0);

			CheckBox checkBox = new CheckBox
			{
				Margin = new Thickness(0, 5, 0, 5),
				Width = double.NaN
			};
			Grid.SetColumn(checkBox, 1);

			gridForLabelComboBox.Children.Add(label);
			gridForLabelComboBox.Children.Add(checkBox);

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ gridForLabelComboBox, PageObjectEnum.LabeledCheckbox },
				{ (TextBlock)label.Content, PageObjectEnum.Label },
				{ checkBox, PageObjectEnum.Checkbox }
			});

			return gridForLabelComboBox;
		}
    }
}
