using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class TextAreaPO : PageObject
    {
        public override UIElement Make()
        {
            TextBox textBox = new TextBox
            {
                Margin = new Thickness(5, 5, 5, 5),
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                AcceptsTab = false,
                Width = DataManager.random.Next(150, 200),
                MinHeight = DataManager.random.Next(100, 150)
            };

            if (DataManager.random.Next(2) == 0)
            {
                textBox.Text = dataManager.RandomString(30, 50);
            }


            SpellCheck.SetIsEnabled(textBox, false);

            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { textBox, PageObjectEnum.TextArea }
            });

            return textBox;
        }
    }
}
