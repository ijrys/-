using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Lottery.OpenSave {
	/// <summary>
	/// WindowOpwnFile.xaml 的交互逻辑
	/// </summary>
	public partial class WindowOpwnFile : Window {
		public WindowOpwnFile() {
			InitializeComponent();
		}
		private string _txtContent;
		public string[] Names { get; private set; } = null;
		public bool IsOK { get; private set; } = false;

		private void Exception(string message) {
			txtPreview.Foreground = new SolidColorBrush(Color.FromRgb(255, 127, 127));
			txtPreview.Text = message;
			btnOK.IsEnabled = false;

		}
		private void OK(string names) {
			txtPreview.Foreground = null;
			txtPreview.Text = names;
			btnOK.IsEnabled = true;
		}
		private void Button_Click(object sender, RoutedEventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = "*.txt";
			ofd.Filter = "txt file|*.txt";
			if (ofd.ShowDialog() == true) {
				string fname = ofd.FileName;
				txtPath.Text = fname;
				try {
					OK(File.ReadAllText(fname));
				}
				catch (Exception ex) {
					Exception(ex.Message);
				}
			}
			else {
				Exception("操作已取消");
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e) {
			Names = null;
			IsOK = false;

			this.Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e) {
			Names = _txtContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
			IsOK = true;

			this.Close();
		}
	}
}
