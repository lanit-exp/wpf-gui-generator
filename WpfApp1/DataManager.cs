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
    public class DataManager
    {
        public static List<PageObjectData> elements = new List<PageObjectData>();

        public Grid mainGrid { set; get; }
        public Grid formBoxGrid { set; get; }
        public StackPanel currentStackPanel { set; get; }
        public Menu menu { set; get; }
        public StatusBar statusBar { set; get; }
        public double menuFontSize { get; set; }
        public double statusBarFontSize { get; set; }
        public int rowInFBG = 0;
        public int colInFBG = 0;

        public static Random random = new Random();

        private static DataManager instance;
        public static int colCount = 5;

        private DataManager() { }

        public static DataManager getInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }

            return instance;
        }

        public void AddNewFiledInFormBoxGrid()
        {
            if (colInFBG < colCount - 1)
            {
                colInFBG++;
            }
            else
            {
                formBoxGrid
                    .RowDefinitions
                    .Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                colInFBG = 0;
                rowInFBG++;
            }
        }

        public string RandomString(int first, int end)
        {
            int rInt = random.Next(first, end);

            const string chars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            return new string(Enumerable.Repeat(chars, rInt)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
