using MVVMDemoNew.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoNew.Models
{
    public class ShoppingItem : ValidatableBindableBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        //public bool IsValid
        //{
        //    get => !HasErrors;
        //}

        private int _quantity;
        [Range(1, 5, ErrorMessage = "The value for {0} must be between a lot and another lot")]
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public ShoppingItem(Guid Id, string Name, string Description, string ImageUrl, int Quantity = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
            this.Quantity = Quantity;
        }
    }
}
