using System;

namespace ShipDrawer.Models
{
    public class DrawVoyage
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Sailed { get; set; }

        public string ShipName { get; set; }
        public string ProductName { get; set; }
    }
}
