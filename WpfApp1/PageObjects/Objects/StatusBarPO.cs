using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfApp1
{
    class StatusBarPO : PageObject
    {
        public override UIElement Make()
        {
            dataManager.statusBar.Items.Add(new StatusBarItem
            {
                Content = new TextBlock { 
                    Text = dataManager.RandomString(7, 15),
                    FontSize = dataManager.statusBarFontSize 
                }
            });

            return null;
        }
    }
}
