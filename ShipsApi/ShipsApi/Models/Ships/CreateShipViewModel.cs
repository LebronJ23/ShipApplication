namespace ShipsApi.Models.Ships
{
    public class CreateShipViewModel
    {
        public string Name { get; set; }

        /// <summary>
        /// Метод действия возврата
        /// </summary>
        public string ReturnAction { get; set; }

        /// <summary>
        /// Контроллер действия возврата
        /// </summary>
        public string ReturnController { get; set; } = "Home";

        /// <summary>
        /// Идентификатор рейса
        /// </summary>
        public string VoyageId { get; set; }
    }
}
