using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
//using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static App app;
		private static string pathToProject = "C:\\Users\\m4ximqa_carry\\source\\repos\\WpfApp1\\WpfApp1\\";
		private static string jsonFolder = "Json\\trees\\";
		private static string photoFolder = "Photos\\";
		private static string calculationsFolder = "Calculations\\";
		private static MainWindow window;
		private static int counter = 901;

		private static Point prev = new Point(0, 0);
		private static double actualHeight;
		private static double actualWidth;

		private static double titlebarHeight = 30;
		private static double indentSize = 5;

		private static string text;

		App()
		{
			InitializeComponent();
		}

		[STAThread]
		public static void Main()
		{
			app = new App();

			string[] filePaths = Directory.GetFiles(pathToProject + jsonFolder);	

			WriteStringToFile(GetDarknetString(), pathToProject + photoFolder + "darknet.txt");

			foreach (string path in filePaths)
			{
				window = new MainWindow(path);
				window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
				window.Show();
				Thread.Sleep(300);
				//app.Run(window);

				actualWidth = window.ActualWidth - 16 + 2 * indentSize;
				actualHeight = window.ActualHeight - 40 + 2 * indentSize + titlebarHeight;
				++counter;

				CaptureScreen(pathToProject + photoFolder + $"photo{counter}.png");

				app.EnumVisual();
				WriteStringToFile(text.Replace(',', '.'), pathToProject + photoFolder + $"photo{counter}.txt");
				
				
				//Thread.Sleep(5000);
				window.Hide();

				if (counter == 1000) break;
			}
		}

		public static void CaptureScreen(string fileName)
		{
            System.Drawing.Graphics graph = null;

			var bmp = new System.Drawing.Bitmap((int) actualWidth, (int) actualHeight);

			graph = System.Drawing.Graphics.FromImage(bmp);

			var t = window.PointToScreen(new Point());

			graph.CopyFromScreen((int) (t.X - indentSize),  (int) (t.Y - titlebarHeight - indentSize), 0, 0, bmp.Size);

			bmp.Save(fileName);
		}


		private void EnumVisual()
        {
			text = "";
			text += ((int) PageObjectEnum.Window).ToString() + " 0.5 0.5 " + (1 - 2 * indentSize / actualWidth).ToString() + " " + (1 - 2 * indentSize / actualHeight).ToString() + "\n";

			foreach (PageObjectData data in DataManager.elements)
            {
				Point relativePoint = data.Element.TransformToAncestor(window)
										 .Transform(new Point(0, 0));

				Calculation(data.Element.ActualHeight, data.Element.ActualWidth, relativePoint, data.ElementId);
			}

			DataManager.elements.Clear();
        }


		private void Calculation(double h, double w, Point point, string elementId)
		{
			double indent = 3;

			double hInWindow = (h + 2 * indent) / actualHeight;
			double wInWindow = (w + 2 * indent) / actualWidth;

			double xCenter = (indentSize + point.X - indent + ((w + 2 * indent) / 2d) ) / actualWidth;
			double yCenter = (indentSize + titlebarHeight + point.Y - indent + ((h + 2 * indent) / 2d) ) / actualHeight;


			text += elementId + " " + xCenter + " " + yCenter + " " + wInWindow + " " + hInWindow + "\n";

		}

		private static void WriteStringToFile(string str, string pathToFile)
        {

			string newStr = str.TrimEnd(new char[] { '\n' });

			try
			{
				using (StreamWriter sw = new StreamWriter(pathToFile, false, System.Text.Encoding.Default))
				{
					sw.WriteLine(newStr);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static string GetDarknetString()
        {
			string str = "";

			foreach (PageObjectEnum pageObjectEnum in Enum.GetValues(typeof(PageObjectEnum)))
            {
				str += pageObjectEnum.ToString() + "\n";
            }

			return str;
        }
	}
}
