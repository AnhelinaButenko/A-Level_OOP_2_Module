namespace HW2Module2.GadgetStore
{
    class ProductService
    {
        private readonly NotificationService _notificationService;

        public ProductService()
        {
            _notificationService = new NotificationService();
        }

        private readonly Dictionary<int, Product> _basket = new Dictionary<int, Product>();

        private List<Product> _products = new List<Product>
        {
             new Product { Id = 1,  Description = "Cool Phone",  Model = "IPhone XI", Price =2000 },
             new Product { Id = 2,  Description = "Beauty Phone",  Model = "IPhone X", Price =2500 },
             new Product { Id = 3,  Description = "Great Phone",  Model = "IPhone XII", Price =2600 },
             new Product { Id = 4,  Description = "Cool Tablet",  Model = "IPhone FN78", Price =2300 },
             new Product { Id = 5,  Description = "Super Watch",  Model = "Samsung 356", Price =1500},
             new Product { Id = 6,  Description = "Great Phone",  Model = "Samsung MN890", Price =900 },
             new Product { Id = 7,  Description = "Cool Phone",  Model = "IPhone VII", Price =1000 },
             new Product { Id = 8,  Description = "Beauty Phone",  Model = "LG 890", Price =1300 },
             new Product { Id = 9,  Description = "Cool Phone",  Model = "Samsung 220G", Price =5000 },
             new Product { Id = 10,  Description = "Smart Watch",  Model = "LG 678DF", Price =4000 },
             new Product { Id = 11,  Description = "Great Tablet",  Model = "Prestigio FL890", Price =1200 },
             new Product { Id = 12,  Description = "Cool Phone",  Model = "IPhone VI", Price =700 },
        };

        public List<Product> GetProducts()
        {
            return _products;
        }

        public List<Product> SelectProducts(Dictionary<int, int> productsIdsInBasket)
        {
            foreach (var item in productsIdsInBasket)
            {
                Product selectedProduct = _products.First(x => x.Id == item.Key);
                selectedProduct.Quantity = item.Value;
                _basket.Add(selectedProduct.Id, selectedProduct);
            }

            //var productsInBasket = new List<Product>();

            //foreach (var item in productsIdsInBasket)
            //{
            //    Product selectedProduct = _products.First(x => x.Id == item.Key);
            //    selectedProduct.Quantity = item.Value;
            //    productsInBasket.Add(selectedProduct);
            //}

            _notificationService.Notify(_basket.Values.ToList());
            return _basket.Values.ToList();
        }

        public List<Product> ReturnProducts(Dictionary<int, int> productsinBasketUpdate)
        {
            foreach (var item in productsinBasketUpdate)
            {
                Product selectedProduct = _products.First(x => x.Id == item.Key);
                selectedProduct.Quantity -= item.Value;
            }

            _notificationService.Notify(_basket.Values.ToList());
            return _basket.Values.ToList();
        }
    }
}
