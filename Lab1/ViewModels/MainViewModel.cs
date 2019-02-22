using ButenkoLab01.Tools;
using ButenkoLab01.Tools.Managers;

using System.Windows;

namespace ButenkoLab01.ViewModels
{
	class MainViewModel : BaseViewModel, ILoaderOwner
	{
		#region Fields
		private Visibility _loaderVisibility = Visibility.Hidden;
		private bool _isControlEnabled = true;
		#endregion

		#region Properties
		public Visibility LoaderVisibility
		{
			get { return _loaderVisibility; }
			set
			{
				_loaderVisibility = value;
				OnPropertyChanged();
			}
		}
		public bool IsControlEnabled
		{
			get { return _isControlEnabled; }
			set
			{
				_isControlEnabled = value;
				OnPropertyChanged();
			}
		}
		#endregion

		internal MainViewModel()
		{
			LoaderManager.Instance.Initialize(this);
		}
	}

}

