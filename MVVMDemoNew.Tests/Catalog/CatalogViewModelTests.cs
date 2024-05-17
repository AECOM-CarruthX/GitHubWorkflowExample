using Moq;
using MVVMDemoNew.Catalog;
using MVVMDemoNew.Models;
using MVVMDemoNew.Services;

namespace MVVMDemoNew.Tests.Catalog
{
    public class CatalogViewModelTests
    {
        private readonly Mock<IShoppingItemsRepository> _mockShoppingItemRepo;
        private readonly CatalogViewModel _catalogViewModel;
        private List<ShoppingItem> _mockShoppingItems = new List<ShoppingItem>() {
                new ShoppingItem(new Guid(), "Blue Pants", "Blue is a great color for pants.", "pack://application:,,,/MVVMDemoNew;component/Images/navy pants.jpg", 1),
                new ShoppingItem(new Guid(), "Small Pants", "Pants. Nice and small.", "pack://application:,,,/MVVMDemoNew;component/Images/big pants.jpg", 1),
                new ShoppingItem(new Guid(), "Jeans", "Cool blue jeans.", "pack://application:,,,/MVVMDemoNew;component/Images/jeans.jpg", 1),
        };

        public CatalogViewModelTests()
        {
            // Arrange for every test
            _mockShoppingItemRepo = new Mock<IShoppingItemsRepository>();
            _mockShoppingItemRepo.Setup(r =>
                r.GetShoppingItems()).Returns(_mockShoppingItems);
            _catalogViewModel = new CatalogViewModel(_mockShoppingItemRepo.Object);
        }

        [Fact]
        public void ShoppingItems_GetValue_ReturnsValuesForShopping()
        {
            // Arrange
            var shoppingItems = _catalogViewModel.ShoppingItems;
            // Assert
            Assert.Equal(shoppingItems, _mockShoppingItems);
        }
    }
}
