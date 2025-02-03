using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public abstract class PageObject
    {
        public UIElement element;

        protected DataManager dataManager;

        public PageObject()
        {
            dataManager = DataManager.getInstance();
            element = Make();
        }

        public abstract UIElement Make();


        protected void AddToPageObjectList(Dictionary<FrameworkElement, PageObjectEnum> dictionary)
        {
            foreach (KeyValuePair<FrameworkElement, PageObjectEnum> entry in dictionary)
            {
                DataManager.elements.Add(new PageObjectData
                {
                    Element = entry.Key,
                    ElementId = ((int) entry.Value).ToString()
                });
            }
        }
    }
}
