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
	/// WindowZ.xaml 的交互逻辑
	/// </summary>
	public partial class WindowZ : MiRaIWindow {
		public WindowZ(List<string> names) : base(names) {
			InitializeComponent();
			Type = "随机直出";
			
		}

		public override void FreshNameList() {
			throw new NotImplementedException();
		}

	}
}
