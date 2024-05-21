using MVVMDemoNew.Core;
using MVVMDemoNew.Models;
using MVVMDemoNew.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace MVVMDemoNew.Catalog
{
    // This would normally be IViewModel, maybe convert bindable base 
    public abstract class ICatalogViewModel : ViewModel
    {
        public RelayCommand<ShoppingItem> AddToCartCommand { get; }
        public RelayCommand GoToCartCommand { get; }
        public event Action<ShoppingItem> AddToCartRequested;
        public event Action GoToCartRequested;
        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }
    }

    public class CatalogViewModel : ICatalogViewModel
    {
        private IShoppingItemsRepository _repository;

        ObservableCollection<ShoppingItem> shoppingItems;

        public RelayCommand<ShoppingItem> AddToCartCommand { get; private set; }
        public RelayCommand GoToCartCommand { get; private set; }

        public event Action<ShoppingItem> AddToCartRequested = delegate { };
        public event Action GoToCartRequested;

        public CatalogViewModel(IShoppingItemsRepository shoppingItemsRepository)
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;

            _repository = shoppingItemsRepository;

            AddToCartCommand = new RelayCommand<ShoppingItem>(OnAddToCart, CanAddToCart);
            GoToCartCommand = new RelayCommand(OnGoToCart);

            ShoppingItems = new ObservableCollection<ShoppingItem>(_repository.GetShoppingItems());
        }

        public ObservableCollection<ShoppingItem> ShoppingItems
        {
            get => shoppingItems;
            set => shoppingItems = value;
        }

        private void OnAddToCart(ShoppingItem shoppingItem)
        {
            AddToCartRequested(shoppingItem);
            Trace.WriteLine(shoppingItem.HasErrors);
        }

        bool CanAddToCart(ShoppingItem shoppingItem) => true;

    }
}
