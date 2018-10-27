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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Lottery {
	/// <summary>
	/// WindowP.xaml 的交互逻辑
	/// </summary>
	public partial class WindowP : MiRaIWindow {
		List<string> res;
		public WindowP(List<string> names) : base(names) {
			InitializeComponent();
			Type = "批量抽取";
			if (names == null) {
				System.Windows.MessageBox.Show("获取不到名单");
				this.Close();
			}
			FreshNameList();
		}

		public override void FreshNameList() {
			int c = NameList.Count;
			if (c < 2) {
				btnNext.IsEnabled = false;
			}
			else {
				sliderCount.Maximum = c - 1;
			}

		}


		private void btnNext_Click(object sender, RoutedEventArgs e) {
			List<string> names = new List<string>(NameList);
			int maxnum = (int)(sliderCount.Value);
			res = new List<string>(maxnum);
			Random r = new Random();
			for (int i = 0; i < maxnum; i++) {
				int id = r.Next(0, names.Count);
				res.Add(names[id]);
				names.RemoveAt(id);
			}

			listRe.ItemsSource = res;

			btnReDo.IsEnabled = true;
			btnSave.IsEnabled = true;
			gridBtnContent.Visibility = Visibility.Collapsed;
			listRe.Visibility = Visibility.Visible;
		}

		private void btnReDo_Click(object sender, RoutedEventArgs e) {
			gridBtnContent.Visibility = Visibility.Visible;
			listRe.Visibility = Visibility.Collapsed;
			btnReDo.IsEnabled = false;
			btnSave.IsEnabled = false;
			listRe.ItemsSource = null;
		}

		private void btnSave_Click(object sender, RoutedEventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.DefaultExt = "*.txt";
			sfd.Filter = "txt file|*.txt";

			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				try {
					FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
					StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
					sw.AutoFlush = true;
					foreach (var item in res) {
						sw.WriteLine(item);
					}
					sw.Flush();
					sw.Close();
					fs.Close();
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
			else {
				MessageBox.Show("操作取消");
			}
		}
	}
}
