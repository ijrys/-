using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Lottery {

	/// <summary>
	/// NameList.xaml 的交互逻辑
	/// </summary>
	public partial class NameListWindow : Window {
		public event BaseDelegateType NameListChanged;

		private List<string> names;
		private ObservableCollection<string> showNames;
		private bool changed = false;
		private bool Changed {
			get => changed;
			set {
				changed = value;
				btnSave.IsEnabled = value;
			}
		}
		public NameListWindow(List<string> names) {
			this.names = names;
			showNames = new ObservableCollection<string>(names);
			InitializeComponent();

			this.listNameList.ItemsSource = showNames;
		}
		private void listNameList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			btnDel.IsEnabled = listNameList.SelectedItems.Count != 0;
		}

		private void Change() {
			Changed = true;
			//this.listNameList.ItemsSource = showNames;
		}

		private void btnAppend_Click(object sender, RoutedEventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = "*.txt";
			ofd.Filter = "txt file|*.txt";
			if (ofd.ShowDialog() == true) {
				string fname = ofd.FileName;
				try {
					string[] names = File.ReadAllLines(fname);
					foreach (var item in names) {
						showNames.Add(item);
					}
					Change();
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
			else {
				MessageBox.Show("已取消");
			}
		}

		private void btnOpen_Click(object sender, RoutedEventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = "*.txt";
			ofd.Filter = "txt file|*.txt";
			if (ofd.ShowDialog() == true) {
				string fname = ofd.FileName;
				try {
					string[] names = File.ReadAllLines(fname);
					showNames.Clear();
					foreach (var item in names) {
						showNames.Add(item);
					}
					Change();
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
			else {
				MessageBox.Show("已取消");
			}
		}

		private void btnDel_Click(object sender, RoutedEventArgs e) {
			if (listNameList.SelectedItems.Count == 0) return;
			List<string> dellist = new List<string>();
			foreach (var item in listNameList.SelectedItems) {
				dellist.Add(item as string);
			}
			foreach (var item in dellist) {
				showNames.Remove(item);
			}
			Change();
		}

		private void btnClear_Click(object sender, RoutedEventArgs e) {
			showNames.Clear();
			Change();
		}

		private void btnSave_Click(object sender, RoutedEventArgs e) {
			if (!Changed) return;
			names.Clear();
			names.AddRange(showNames);
			Changed = false;
			FileStream fs = null;
			StreamWriter sw = null;
			try {
				fs = new FileStream("names.txt", FileMode.Create);
				sw = new StreamWriter(fs);
				sw.AutoFlush = true;
				foreach (var item in names) {
					sw.WriteLine(item);
				}
				sw.Flush();
			} catch {
				MessageBox.Show("在保存名单时发生错误，名单将无法保存在磁盘上");
			} finally {
				sw.Close();
				fs.Close();
			}
			NameListChanged?.Invoke();
		}
	}
}
