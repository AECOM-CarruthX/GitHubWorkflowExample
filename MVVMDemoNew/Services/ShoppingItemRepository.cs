using MVVMDemoNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoNew.Services
{
    public interface IShoppingItemsRepository
    {
        List<ShoppingItem> GetShoppingItems();
    }
    public class ShoppingItemsRepository : IShoppingItemsRepository
    {
        public List<ShoppingItem> GetShoppingItems() => new List<ShoppingItem>()
            {
                new ShoppingItem(new Guid(), "Navy Pants", "Navy is a great color for pants.", "pack://application:,,,/MVVMDemoNew;component/Images/navy pants.jpg", 1),
                new ShoppingItem(new Guid(), "Big Pants", "Pants. Nice and big.", "pack://application:,,,/MVVMDemoNew;component/Images/big pants.jpg", 1),
                new ShoppingItem(new Guid(), "Jeans", "Cool blue jeans.", "pack://application:,,,/MVVMDemoNew;component/Images/jeans.jpg", 1),
                new ShoppingItem(new Guid(), "Red Pants", "Red is a great color for pants.", "pack://application:,,,/MVVMDemoNew;component/Images/red pants.jpg", 1),
                new ShoppingItem(new Guid(), "Khaki Pants", "To dress cool.", "pack://application:,,,/MVVMDemoNew;component/Images/khaki pants.jpg", 1)
            };
    }
}
