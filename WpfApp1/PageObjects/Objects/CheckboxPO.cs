using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class CheckboxPO : PageObject
    {
        public override UIElement Make()
        {
            CheckBox checkBox = new CheckBox();

            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { checkBox, PageObjectEnum.Checkbox }
            });

            return checkBox;
        }
    }
}
