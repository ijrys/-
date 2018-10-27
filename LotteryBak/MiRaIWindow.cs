using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lottery {
	abstract class MiRaIWindow: Window {
		public abstract void SetTheme(Theme theme);
	}
}
