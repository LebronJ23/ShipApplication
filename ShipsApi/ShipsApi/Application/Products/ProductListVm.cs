using System.Collections.Generic;

namespace ShipsApi.Application.Products
{
    public class ProductListVm
    {
        public IList<ProductVm> Products { get; set; } = new List<ProductVm>();
    }
}
