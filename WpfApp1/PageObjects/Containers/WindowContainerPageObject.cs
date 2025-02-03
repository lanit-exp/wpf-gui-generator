using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfApp1
{
    class WindowContainerPageObject : ContainerPageObject
    {
        public override UIElement Make()
        {
			#region Make main grid
			Grid mainGrid = new Grid { };
			mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

			dataManager.mainGrid = mainGrid;
			#endregion

			#region Make menu
			Menu menu = new Menu
			{
				Background = new SolidColorBrush(Colors.LightGray),
				VerticalAlignment = VerticalAlignment.Top
			};

			Grid.SetRow(menu, 0);

			dataManager.menu = menu;
			#endregion

			#region Make formBox grid
			Grid formBoxGrid = new Grid();
			Grid.SetRow(formBoxGrid, 1);

			formBoxGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			for (int i = 0; i < DataManager.colCount; ++i)
			{
				formBoxGrid
					.ColumnDefinitions
					.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
			}

			dataManager.formBoxGrid = formBoxGrid;
			#endregion

			#region Make statusBar
			StatusBar statusBar = new StatusBar();
			DockPanel.SetDock(statusBar, Dock.Bottom);
			Grid.SetRow(statusBar, 2);

			DataManager.elements.Add(new PageObjectData
			{
				Element = statusBar,
				ElementId = ((int)PageObjectEnum.StatusBar).ToString()
			});

			dataManager.statusBar = statusBar;
			#endregion

			#region Add elements to main grid
			mainGrid.Children.Add(menu);
			mainGrid.Children.Add(formBoxGrid);
			mainGrid.Children.Add(statusBar);
			#endregion

			return formBoxGrid;
		}

        public override void AddElement(PageObject pageObject)
        {
			Grid.SetColumn(pageObject.element, dataManager.colInFBG);
			Grid.SetRow(pageObject.element, dataManager.rowInFBG);
			dataManager.AddNewFiledInFormBoxGrid();

            base.AddElement(pageObject);
        }
    }
}
