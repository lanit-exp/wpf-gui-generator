using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class NodeContainerPageObject : ContainerPageObject
    {
		public override UIElement Make()
		{
			StackPanel stackPanel = new StackPanel
			{
				HorizontalAlignment = HorizontalAlignment.Left
			};

			return stackPanel;
		}
	}
}
