using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class MenuItemPO : PageObject
    {
        public override UIElement Make()
        {
            MenuItem menuItem = new MenuItem
            {
                Header = dataManager.RandomString(7, 15),
                FontSize = DataManager.getInstance().menuFontSize
            };

            dataManager.menu.Items.Add(menuItem);

            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { menuItem, PageObjectEnum.MenuItem }
            });

            return null;
        }
    }
}
