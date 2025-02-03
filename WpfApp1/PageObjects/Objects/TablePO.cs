using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WpfApp1.TableData;

namespace WpfApp1
{
	class TablePO : PageObject
	{
		public override UIElement Make()
		{
			DataGrid table = new DataGrid
			{
				Margin = new Thickness(5, 5, 5, 5)
			};

			int tableRow = DataManager.random.Next(4, 10);
			int tableCol = DataManager.random.Next(4, 10);

			for (int i = 0; i < tableCol; ++i)
			{
				DataGridTextColumn col = new DataGridTextColumn();
				table.Columns.Add(col);
				col.Binding = new Binding("data" + (i + 1));
				col.Header = dataManager.RandomString(5, 7);
			}

			for (int i = 0; i < tableRow; ++i)
			{
				switch (tableCol)
                {
					case 4:
						table.Items.Add(new TableData4
						{
							data1 = dataManager.RandomString(7, 15),
							data2 = dataManager.RandomString(7, 15),
							data3 = dataManager.RandomString(7, 15),
							data4 = dataManager.RandomString(7, 15)
						});
						break;
					case 5:
						table.Items.Add(new TableData5
						{
							data1 = dataManager.RandomString(7, 15),
							data2 = dataManager.RandomString(7, 15),
							data3 = dataManager.RandomString(7, 15),
							data4 = dataManager.RandomString(7, 15),
							data5 = dataManager.RandomString(7, 15)
						});
						break;
					case 6:
						table.Items.Add(new TableData6
						{
							data1 = dataManager.RandomString(7, 15),
							data2 = dataManager.RandomString(7, 15),
							data3 = dataManager.RandomString(7, 15),
							data4 = dataManager.RandomString(7, 15),
							data5 = dataManager.RandomString(7, 15),
							data6 = dataManager.RandomString(7, 15)
						});
						break;
					case 7:
						table.Items.Add(new TableData7
						{
							data1 = dataManager.RandomString(7, 15),
							data2 = dataManager.RandomString(7, 15),
							data3 = dataManager.RandomString(7, 15),
							data4 = dataManager.RandomString(7, 15),
							data5 = dataManager.RandomString(7, 15),
							data6 = dataManager.RandomString(7, 15),
							data7 = dataManager.RandomString(7, 15)
						});
						break;
					case 8:
						table.Items.Add(new TableData8
						{
							data1 = dataManager.RandomString(7, 15),
							data2 = dataManager.RandomString(7, 15),
							data3 = dataManager.RandomString(7, 15),
							data4 = dataManager.RandomString(7, 15),
							data5 = dataManager.RandomString(7, 15),
							data6 = dataManager.RandomString(7, 15),
							data7 = dataManager.RandomString(7, 15),
							data8 = dataManager.RandomString(7, 15)
						});
						break;
					case 9:
						table.Items.Add(new TableData9
						{
							data1 = dataManager.RandomString(7, 15),
							data2 = dataManager.RandomString(7, 15),
							data3 = dataManager.RandomString(7, 15),
							data4 = dataManager.RandomString(7, 15),
							data5 = dataManager.RandomString(7, 15),
							data6 = dataManager.RandomString(7, 15),
							data7 = dataManager.RandomString(7, 15),
							data8 = dataManager.RandomString(7, 15),
							data9 = dataManager.RandomString(7, 15)
						});
						break;
				}

			}

			AddToPageObjectList(new Dictionary<FrameworkElement, PageObjectEnum>
			{
				{ table, PageObjectEnum.Table }
			});

			return table;
		}
	}
}
