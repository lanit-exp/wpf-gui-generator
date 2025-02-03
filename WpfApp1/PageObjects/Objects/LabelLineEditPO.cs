using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class LabelLineEditPO : PageObject
    {
        public override UIElement Make()
        {
			Grid gridForLabelLineEdit = new Grid
			{
				Margin = new Thickness(5, 5, 5, 5),
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center
			};
			gridForLabelLineEdit.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			gridForLabelLineEdit.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			Label label = new Label
			{
				Content = new TextBlock { Text = DataManager.getInstance().RandomString(7, 15) },
				FontSize = DataManager.random.Next(10, 15)
			};

			TextBox textBox = new TextBox
			{
				MinWidth = DataManager.random.Next(70, 200),
				MinHeight = DataManager.random.Next(20, 40),
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center
			};

			Grid.SetColumn(textBox, 1);

			gridForLabelLineEdit.Children.Add(label);
			gridForLabelLineEdit.Children.Add(textBox);

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ gridForLabelLineEdit, PageObjectEnum.LabeledLineEdit },
				{ (TextBlock)label.Content, PageObjectEnum.Label },
				{ textBox, PageObjectEnum.LineEdit }
			});

			return gridForLabelLineEdit;
		}
    }
}
