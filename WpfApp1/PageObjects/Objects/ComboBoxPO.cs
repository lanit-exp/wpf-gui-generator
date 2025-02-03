using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class ComboBoxPO : PageObject
    {
        public override UIElement Make()
        {
            ComboBox comboBox = new ComboBox {
                MinWidth = DataManager.random.Next(70, 200),
                MinHeight = DataManager.random.Next(20, 30)
            };
            //ComboBoxItem comboBoxItem = new ComboBoxItem { Content = new TextBlock { Text = dataManager.RandomString(7, 10) } };
            //comboBox.ItemsSource = new List<ComboBoxItem>() { comboBoxItem };
            //comboBox.SelectedItem = comboBoxItem;


            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { comboBox, PageObjectEnum.ComboBox }
            });

            return comboBox;
        }
    }
}
