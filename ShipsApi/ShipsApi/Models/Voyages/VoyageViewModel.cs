using ShipsApi.Application.Products;
using ShipsApi.Application.Ships;
using ShipsApi.Application.Voyages;

namespace ShipsApi.Models.Voyages
{
    public class VoyageViewModel
    {
        public VoyageVm Voyage{ get; set; }
        public ShipListVm Ships { get; set; }
        public ProductListVm Products { get; set; }

        /// <summary>
        /// Метод действия
        /// </summary>
        public string Action { get; set; } = "Create";

        /// <summary>
        /// UI тема
        /// </summary>
        public string Theme { get; set; } = "primary";

        /// <summary>
        /// Доступ к изменениям
        /// </summary>
        public bool ReadOnly { get; set; } = false;

    }
}
