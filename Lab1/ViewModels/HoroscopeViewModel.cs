using ButenkoLab01.Tools;
using ButenkoLab01.Tools.Managers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ButenkoLab01.ViewModels
{
	internal class HoroscopViewModel : BaseViewModel
	{
		#region Fields
		public static readonly String[] ChineseYear = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };

		private DateTime _birthDay = DateTime.Today;
		private int _age;
		private String _chineseHoroscope = "Unknown";
		private String _westHoroscope = "Unknown";
		private RelayCommand<object> _exitCommand;
		private RelayCommand<object> _beginCommand;

		#endregion


		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
				if (_age > 135 || _birthDay > DateTime.Today)
				{
					throw new Exception("Wrong date of birthday");//TODO
				}
				OnPropertyChanged();
			}
		}
		public String WestHoroscope
		{
			get
			{
				return _westHoroscope;
			}
			set
			{
				_westHoroscope = value;
				OnPropertyChanged();
			}
		}
		private async void StartDefining(object obj)
		{
			LoaderManager.Instance.ShowLoader();
			await Task.Run(() => Thread.Sleep(2000));
			try
			{

				await Task.Run(() => Thread.Sleep(2000));
				DefineAge();
				if (isBirthdayToday())
				{
					MessageBox.Show("Happy birthday to you)))");
				}

				DefineChineseHoroscope();
				DefineTheWestHoroscope();


			}
			catch (Exception)
			{
				MessageBox.Show("Wrong date!");
			}
			finally
			{
				LoaderManager.Instance.HideLoader();
			}
		}
		private void DefineAge()
		{
			Age = (int)((DateTime.Today - _birthDay).Days / 365);
		}
		public String ChineseHoroscope
		{
			get
			{
				return _chineseHoroscope;
			}
			set
			{
				_chineseHoroscope = value;
				OnPropertyChanged();
			}
		}
		public DateTime DateOfBirth
		{
			get
			{
				return _birthDay;
			}
			set
			{
				_birthDay = value;
				OnPropertyChanged();
			}
		}
		private bool isBirthdayToday()
		{
			return _birthDay == DateTime.Today;
		}
		private void DefineTheWestHoroscope()
		{
			int day = _birthDay.Day;
			int month = _birthDay.Month;
			if (day >= 22 && month == 12 || day <= 20 && month == 1)
			{
				WestHoroscope = "Capricorn";
			}
			else if (day >= 21 && month == 1 || day <= 19 && month == 2)
			{
				WestHoroscope = "Aquarius";
			}
			else if (day >= 20 && month == 2 || day <= 20 && month == 3)
			{
				WestHoroscope = "Pisces";
			}
			else if (day >= 21 && month == 3 || day <= 19 && month == 4)
			{
				WestHoroscope = "Aries";
			}
			else if (day >= 20 && month == 4 || day <= 20 && month == 5)
			{
				WestHoroscope = "Taurus";
			}
			else if (day >= 21 && month == 5 || day <= 21 && month == 6)
			{
				WestHoroscope = "Gemini";
			}
			else if (day >= 22 && month == 6 || day <= 23 && month == 7)
			{
				WestHoroscope = "Cancer";
			}
			else if (day >= 24 && month == 7 || day <= 23 && month == 8)
			{
				WestHoroscope = "Leo";
			}
			else if (day >= 24 && month == 8 || day <= 22 && month == 9)
			{
				WestHoroscope = "Virgo";
			}
			else if (day >= 23 && month == 9 || day <= 22 && month == 10)
			{
				WestHoroscope = "Libra";
			}
			else if (day >= 23 && month == 10 || day <= 22 && month == 11)
			{
				WestHoroscope = "Scorpio";
			}
			else WestHoroscope = "Sagittarius";
		}
		public RelayCommand<Object> BeginCommand
		{
			get
			{
				return _beginCommand ?? (_beginCommand = new RelayCommand<object>(
						  StartDefining, o => CanExecuteCommand()));
			}
		}
		public RelayCommand<Object> ExitCommand
		{
			get
			{
				return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0)));
			}
		}

		private void DefineChineseHoroscope()
		{
			ChineseHoroscope = ChineseYear[_birthDay.Year % 12];
		}
		private bool CanExecuteCommand()
		{
			return !String.IsNullOrWhiteSpace(_birthDay.ToString());
		}

	}
}
