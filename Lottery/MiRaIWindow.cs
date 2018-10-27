using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lottery {
	public delegate void BaseDelegateType();
	public abstract class MiRaIWindow:Window {
		public string Type { set; get; } = "MiRaI";
		public string State { set; get; } = "未开始";
		public List<string> NameList { get => _names; set => _names = value; }

		public abstract void FreshNameList();
		private List<string> _names;
		public MiRaIWindow (List<string> names) {
			this.NameList = names;
		}
	}
}
