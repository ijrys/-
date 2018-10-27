using System;
using System.Collections.Generic;
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

namespace Lottery {
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : MiRaIWindow {
		Theme theme = new Theme();
		public MainWindow() {
			InitializeComponent();
		}

		public void SetTheme (Theme theme) {

		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			var a = Application.Current;
			var b = a.Resources;
		}
	}
}
