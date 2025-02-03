using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1
{
    class ListPO : PageObject
    {
        public override UIElement Make()
        {
            ListBox listBox = new ListBox {
                Margin = new Thickness(5, 5, 5, 5) 
            };

            for (int i = 0; i < DataManager.random.Next(1, 10); ++i)
            {
                listBox.Items.Add(new ListBoxItem { 
                    Content = dataManager.RandomString(7, 15)
                });
            }

            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { listBox, PageObjectEnum.List }
            });

            return listBox;
        }
    }
}
