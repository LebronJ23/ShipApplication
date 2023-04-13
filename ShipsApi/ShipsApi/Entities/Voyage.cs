using System;

namespace ShipsApi.Entities
{
    public class Voyage
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Sailed { get; set; }

        public int ShipId { get; set; }
        public Ship Ship { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
