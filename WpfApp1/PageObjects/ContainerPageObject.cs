using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public abstract class ContainerPageObject : PageObject
    {
		public virtual void AddElement(PageObject pageObject)
        {
			(element as Panel).Children.Add(pageObject.element);
		}
	}
}
