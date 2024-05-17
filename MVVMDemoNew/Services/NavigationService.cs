using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemoNew.Core;

namespace MVVMDemoNew.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo(ViewModel viewModel);
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        //private readonly Func<Type, ViewModel> _viewModelFactory;
        private ViewModel _currentView;

        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged(nameof(_currentView));
            }
        }

        public NavigationService()
        {
            //_viewModelFactory = viewModelFactory;
        }

        //public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
        //{
        //    ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        //    CurrentView = viewModel;
        //}

        public void NavigateTo(ViewModel viewModel) => CurrentView = viewModel;
    }


}
