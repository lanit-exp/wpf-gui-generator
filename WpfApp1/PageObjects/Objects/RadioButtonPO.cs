using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class RadioButtonPO : PageObject
    {
        public override UIElement Make()
        {
            RadioButton radioButton = new RadioButton();

            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { radioButton, PageObjectEnum.RadioButton }
            });

            return radioButton;
        }

    }
}
