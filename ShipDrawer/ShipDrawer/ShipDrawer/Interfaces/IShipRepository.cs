using ShipDrawer.Models;
using System.Collections.Generic;

namespace ShipDrawer.Interfaces
{
    public interface IShipRepository
    {
        DrawerModel GetAllVoyages();
    }
}
