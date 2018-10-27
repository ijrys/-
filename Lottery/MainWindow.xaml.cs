using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Lottery.OpenSave;

namespace Lottery {
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window {
		private ObservableCollection<MiRaIWindow> windows = new ObservableCollection<MiRaIWindow>();
		private NameListWindow NameListWindow = null;
		private List<string> names = new List<string>();

		public MainWindow() {
			InitializeComponent();
			listWindowManager.ItemsSource = windows;

			InitNameList();
		}

		private void btnNewG_Click(object sender, RoutedEventArgs e) {
			//return;
			#region 主题改变测试
			//var a = App.Current.Resources;
			//var b = a.Keys;
			//a["BrushBackGround"] = new SolidColorBrush(Color.FromRgb(238, 238, 238));
			//a["BrushControlBackGround"] = new SolidColorBrush(Color.FromRgb(240, 240, 240));
			//a["BrushForeGround"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
			//a["BrushNEControlBackGround"] = new SolidColorBrush(Color.FromRgb(128, 128, 128)); 
			#endregion

			WindowOpwnFile wof = new WindowOpwnFile();
			wof.ShowDialog();
			//a["BrushBackGround"] = new Brush()
		}

		private void btnNewZ_Click(object sender, RoutedEventArgs e) {
			WindowZ wz = new WindowZ(names);
			wz.Closing += Wz_Closing;
			windows.Add(wz);

			wz.Show();
		}

		private void btnNewP_Click(object sender, RoutedEventArgs e) {
			WindowP wz = new WindowP(names);
			wz.Closing += Wz_Closing;
			windows.Add(wz);

			wz.Show();
		}

		private void Wz_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			windows.Remove(sender as MiRaIWindow);
		}


		private void BtnToWindow_Click(object sender, RoutedEventArgs e) {
			(((sender as Button).Parent as Grid).DataContext as Window).Focus();
		}

		/// <summary>
		/// 名单管理页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNameList_Click(object sender, RoutedEventArgs e) {
			if (NameListWindow == null) {
				NameListWindow = new NameListWindow(this.names);
				NameListWindow.Closing += (object asender, System.ComponentModel.CancelEventArgs args) => {
					NameListWindow = null;
				};
				NameListWindow.NameListChanged += NameListWindow_NameListChanged;
				NameListWindow.Show();
			}
			else {
				NameListWindow.Focus();
			}

		}

		private void NameListWindow_NameListChanged() {
			if (names.Count == 0) {
				btnNewG.IsEnabled = false;
				btnNewP.IsEnabled = false;
				btnNewZ.IsEnabled = false;
			} else {
				btnNewG.IsEnabled = true;
				btnNewP.IsEnabled = true;
				btnNewZ.IsEnabled = true;
			}
			foreach (var item in windows) {
				item.FreshNameList();
			}
		}


		#region 名单相关
		/// <summary>
		/// 初始化名单
		/// </summary>
		private void InitNameList() {
			try {
				names.AddRange(File.ReadAllLines("names.txt", Encoding.UTF8));
				if (names.Count < 2) {
					btnNewG.IsEnabled = false;
					btnNewP.IsEnabled = false;
					btnNewZ.IsEnabled = false;
					MessageBox.Show("名单中人数过少（少于2人），将无法进行抽取");
				}
			}
			catch {
				MessageBox.Show("找不到名单文件");
				btnNewG.IsEnabled = false;
				btnNewP.IsEnabled = false;
				btnNewZ.IsEnabled = false;
			}
		}

		#endregion
	}
}
