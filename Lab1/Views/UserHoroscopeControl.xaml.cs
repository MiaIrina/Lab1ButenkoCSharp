
using System.Windows.Controls;

using ButenkoLab01.ViewModels;
namespace ButenkoLab01.Views
{
	/// <summary>
	/// Логика взаимодействия для UserHoroscopeControl.xaml
	/// </summary>
	public partial class UserHoroscopeControl : UserControl
	{
		public UserHoroscopeControl()
		{
			InitializeComponent();
			DataContext = new HoroscopViewModel();
		}
	}
}
