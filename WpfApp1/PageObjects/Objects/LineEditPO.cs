using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class LineEditPO : PageObject
    {
        public override UIElement Make()
        {
			TextBox textBox = new TextBox
			{
				MinWidth = DataManager.random.Next(70, 200),
				MinHeight = DataManager.random.Next(20, 40),
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center
			};

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ textBox, PageObjectEnum.LineEdit }
			});

			return textBox;
		}
    }
}
