using KampGameProject.Abstract;

namespace KampGameProject.Entities
{
    public class Game:IEntity
    {
        public int GameId { get; set; }
        public int GameCategoryId { get; set; }
        public string GameName { get; set; }
        public decimal GameUnitPrice { get; set; }
        public int GameUnitsInStock { get; set; }
    }
}
