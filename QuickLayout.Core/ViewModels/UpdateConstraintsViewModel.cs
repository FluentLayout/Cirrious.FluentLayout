using MvvmCross.Core.ViewModels;

namespace QuickLayout.Core.ViewModels
{
	public class UpdateConstraintsViewModel : MvxViewModel
	{
		private bool _active = true;
		public bool Active
		{
			get { return _active; }
			set
			{
				_active = value;
				RaisePropertyChanged(() => Active);
			}
		}

		private float _constant = 200;
		public float Constant
		{
			get { return _constant; }
			set
			{
				_constant = value;
				RaisePropertyChanged(() => Constant);
			}
		}
	}
}

