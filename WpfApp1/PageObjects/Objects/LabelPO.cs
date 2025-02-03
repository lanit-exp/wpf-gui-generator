using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class LabelPO : PageObject
    {
        public override UIElement Make()
        {
			Label label = new Label
			{
				Content = new TextBlock { Text = dataManager.RandomString(7, 15) },
				FontSize = DataManager.random.Next(10, 15)
			};

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ (TextBlock)label.Content, PageObjectEnum.Label }
			});

			return label;
		}
    }
}
