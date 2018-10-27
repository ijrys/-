using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lottery {
	public class Theme : INotifyPropertyChanged {
		string _font;
		double _fontSize;
		Brush _backGround;
		Brush _foreGround;

		public string Font {
			get => _font;
			set {
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Font"));
				_font = value;
			}
		}
		public double FontSize {
			get => _fontSize;
			set {
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FontSize"));
				_fontSize = value;
			}
		}
		public Brush BackGround {
			get => _backGround;
			set {
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FontSize"));
				_backGround = value;
			}
		}
		public Brush ForeGround {
			get => _foreGround;
			set {
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FontSize"));
				_foreGround = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;


		public Theme () {
			_backGround = new SolidColorBrush(Color.FromRgb(15, 15, 31));
		}
	}
}
