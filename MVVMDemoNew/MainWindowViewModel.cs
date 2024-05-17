using MVVMDemoNew.Cart;
using MVVMDemoNew.Catalog;
using MVVMDemoNew.Core;
using MVVMDemoNew.Models;
using MVVMDemoNew.Services;

namespace MVVMDemoNew
{
    public abstract class IMainWindowViewModel : ViewModel
    {
    }

    public class MainWindowViewModel : IMainWindowViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(_navigation));
            }
        }

        private ICatalogViewModel _catalogViewModel;
        private ICartViewModel _cartViewModel;

        public MainWindowViewModel(INavigationService navService, ICatalogViewModel catalogViewModel, ICartViewModel cartViewModel)
        {
            Navigation = navService;
            _catalogViewModel = catalogViewModel;
            _cartViewModel = cartViewModel;
            _catalogViewModel.AddToCartRequested += AddToCart;
            _catalogViewModel.GoToCartRequested += NavigateToCart;
            Navigation.NavigateTo(_cartViewModel);
        }

        private void AddToCart(ShoppingItem shoppingItem) => _cartViewModel.AddToCart(shoppingItem);

        private void NavigateToCart() => Navigation.NavigateTo(_cartViewModel);
    }
}
