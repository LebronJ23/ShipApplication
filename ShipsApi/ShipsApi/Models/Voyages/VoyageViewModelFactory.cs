using ShipsApi.Application.Products;
using ShipsApi.Application.Ships;
using ShipsApi.Application.Voyages;
using System.Collections.Generic;

namespace ShipsApi.Models.Voyages
{
    public static class VoyageViewModelFactory
    {
        public static VoyageViewModel Create(VoyageVm voyageVm, ProductListVm products, ShipListVm ships)
        {
            return new VoyageViewModel
            {
                Voyage = voyageVm,
                Products = products,
                Ships = ships,
            };
        }

        public static VoyageViewModel Edit(VoyageVm voyageVm, ProductListVm products, ShipListVm ships)
        {
            return new VoyageViewModel
            {
                Voyage = voyageVm,
                Products = products,
                Ships = ships,
                Action = "Edit",
                Theme = "warning",
            };
        }

        public static VoyageViewModel Delete(VoyageVm voyageVm, ProductListVm products, ShipListVm ships)
        {
            return new VoyageViewModel
            {
                Voyage = voyageVm,
                Products = products,
                Ships = ships,
                Action = "Delete",
                Theme = "danger",
                ReadOnly = true,
            };
        }
    }
}
