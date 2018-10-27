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
using System.Windows.Shapes;

namespace Lottery {
	/// <summary>
	/// WindowG.xaml 的交互逻辑
	/// </summary>
	public partial class WindowG : MiRaIWindow {
		public WindowG(List<string> names):base(names) {
			InitializeComponent();
			Type = "滚动生成";
		}

		public override void FreshNameList() {
			throw new NotImplementedException();
		}

	}
}
