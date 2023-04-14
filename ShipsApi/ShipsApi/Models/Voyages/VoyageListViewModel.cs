using ShipsApi.Application.Products;
using ShipsApi.Application.Ships;
using ShipsApi.Application.Voyages;

namespace ShipsApi.Models.Voyages
{
    public class VoyageListViewModel
    {
        public VoyageListVm Voyages { get; set; }
        public ShipListVm ShipList { get; set; }
        public ProductListVm ProductList { get; set; }
    }
}
