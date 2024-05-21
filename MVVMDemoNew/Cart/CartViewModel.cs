using MVVMDemoNew.Core;
using MVVMDemoNew.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVVMDemoNew.Cart
{
    public abstract class ICartViewModel : ViewModel
    {
        public ObservableCollection<ShoppingItem> CartItems { get; set; }
        public RelayCommand<ShoppingItem> EditItemCommand { get; }
        public RelayCommand<ShoppingItem> DeleteItemCommand { get; }
        public RelayCommand ReturnToCatalogCommand { get; }

        public event Action<ShoppingItem> EditItemRequested;
        public event Action ReturnToCatalogRequested;

        public abstract void AddToCart(ShoppingItem shoppingItem);
    }

    public class CartViewModel : ICartViewModel
    {
        ObservableCollection<ShoppingItem> cartItems;
        public ObservableCollection<ShoppingItem> CartItems
        {
            get => cartItems;
            set => cartItems = value;
        }

        public RelayCommand<ShoppingItem> EditItemCommand { get; private set; }
        public RelayCommand<ShoppingItem> DeleteItemCommand { get; private set; }
        public RelayCommand ReturnToCatalogCommand { get; private set; }

        public event Action<ShoppingItem> EditItemRequested = delegate { };
        public event Action ReturnToCatalogRequested = delegate { };

        public CartViewModel()
        {
            CartItems = new ObservableCollection<ShoppingItem>()
            {
                new ShoppingItem(new Guid(), "Navy Jeans", "Navy is a great color for pants.", "pack://application:,,,/MVVMDemoNew;component/Images/navy pants.jpg", 1),
            };
            EditItemCommand = new RelayCommand<ShoppingItem>(OnEditItem);
            DeleteItemCommand = new RelayCommand<ShoppingItem>(OnDeleteItem);
            ReturnToCatalogCommand = new RelayCommand(OnReturnToCatalog);
        }

        public override void AddToCart(ShoppingItem shoppingItem)
        {
            if (cartItems == null)
            {
                Trace.WriteLine("Cart Items is null");
            }
            CartItems.Add(shoppingItem);
            Trace.WriteLine(cartItems);
        }

        private void OnReturnToCatalog() => ReturnToCatalogRequested();

        private void OnEditItem(ShoppingItem shoppingItem) => EditItemRequested(shoppingItem);
        private void OnDeleteItem(ShoppingItem shoppingItem) => CartItems.Remove(shoppingItem);
    }
}
