using System.Collections.Generic;

namespace ShipDrawer.Models
{
    public class DrawerModel
    {
        public List<DrawVoyage> UnderLoading { get; set; } = new List<DrawVoyage>();
        public List<DrawVoyage> OnTheWay { get; set; } = new List<DrawVoyage>();
        public List<DrawVoyage> Gone { get; set; } = new List<DrawVoyage>();
    }
}
