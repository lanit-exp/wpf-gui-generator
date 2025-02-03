using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1
{
    class TreeViewPO : PageObject
    {
        public override UIElement Make()
        {
            TreeView treeView = new TreeView {
                Margin = new Thickness(5, 5, 5, 5)
            };

            int treeHeight = DataManager.random.Next(1, 3);

            for (int i = 0; i < DataManager.random.Next(1, 5); ++i)
            {
                TreeViewItem treeViewItem = new TreeViewItem
                {
                    Header = dataManager.RandomString(7, 15),
                    IsExpanded = true
                };

                treeView.Items.Add(treeViewItem);

                MakeTreeViewRecursion(treeViewItem, treeHeight, 0);
            }

            AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
            {
                { treeView, PageObjectEnum.TreeView }
            });

            return treeView;
        }
   

        private void MakeTreeViewRecursion(TreeViewItem treeViewItem, int treeHeight, int currentHeight)
        {
            if (currentHeight < treeHeight)
            {
                for (int i = 0; i < DataManager.random.Next(1, 3); ++i)
                {
                    TreeViewItem treeViewItemCurrent = new TreeViewItem
                    {
                        Header = dataManager.RandomString(7, 15),
                        IsExpanded = true
                    };

                    treeViewItem.Items.Add(treeViewItemCurrent);

                    MakeTreeViewRecursion(treeViewItemCurrent, treeHeight, currentHeight + 1);
                }
            }
        }
    }
}
