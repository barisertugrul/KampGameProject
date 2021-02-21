using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;

namespace KampGameProject.Concrete
{
    public class GameManager : BaseTableOperationsManager<Game>
    {
        public GameManager(IDbAdapterService<Game> dbService):base(dbService)
        {
            //_dbService = dbService;
        }

        public override void ConsoleMenu()
        {
            string[] menuItems = new string[] { "1-Add New Game", "2-Update Game", "3-Delete Game", "4-Games List", "5-Return MAIN MENU" };
            string val;
            int selected;

            ConsoleTexts.WriteMenuConsoleTexts("GAME MANAGER", menuItems);
            Console.Write("\nSelect number of menu item: ");
            val = Console.ReadLine();
            selected = Convert.ToInt32(val);
            switch (selected)
            {
                case 1:
                    ConsoleAddForm();
                    ConsoleMenu();
                    break;
                case 2:
                    ConsoleUpdateForm();
                    ConsoleMenu();
                    break;
                case 3:
                    ConsoleDeleteForm();
                    ConsoleMenu();
                    break;
                case 4:
                    ConsoleListView();
                    ConsoleMenu();
                    break;
                case 5:
                    MainConsoleManager.MainMenu();
                    break;
                default:
                    Console.WriteLine("You made the wrong choice. Please try again.");
                    ConsoleMenu();
                    break;
            }
        }

        public override void ConsoleAddForm()
        {
            Game game = new Game();
            Console.Write("\nType game name: ");
            game.GameName = Console.ReadLine();
            Console.Write("\nType game category id: ");
            game.GameCategoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nType game unit price: ");
            game.GameUnitPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("\nType game unit in stock: ");
            game.GameUnitsInStock = Convert.ToInt32(Console.ReadLine());
            Add(game);
        }

        public override void ConsoleUpdateForm()
        {
            string name;
            string catId;
            string price;
            string stock;

            ConsoleListView();
            Game game = new Game();
            Console.Write("\nEnter the GameId of the game to be updated: ");
            game.GameId = Convert.ToInt32(Console.ReadLine());
            game = GetById(game.GameId);
            Console.Write("\nType new game name (Leave blank if you do not want to change): ");
            name = Console.ReadLine();
            if (name != "") game.GameName = name;
            Console.Write("\nType new game category id (Leave blank if you do not want to change): ");
            catId = Console.ReadLine();
            if (catId != "") game.GameCategoryId = Convert.ToInt32(catId);
            Console.Write("\nType new game unit price (Leave blank if you do not want to change): ");
            price = Console.ReadLine();
            if (price != "") game.GameUnitPrice = Convert.ToDecimal(price);
            Console.Write("\nType new game unit in stock (Leave blank if you do not want to change): ");
            stock = Console.ReadLine();
            if (stock != "") game.GameUnitsInStock = Convert.ToInt32(stock);
            Update(game);
        }

        public override void ConsoleDeleteForm()
        {
            ConsoleListView();
            Game game = new Game();
            Console.Write("\nEnter the GameId of the game to be removed: ");
            game.GameId = Convert.ToInt32(Console.ReadLine());
            Delete(game);
        }

        public override void ConsoleListView()
        {
            string[] listItems = new string[GetList().Count];
            int i = 0;
            foreach (Game gameItem in GetList())
            {
                listItems[i] = gameItem.GameId + "-" + gameItem.GameName + " (" + gameItem.GameUnitPrice + " TL)";
                i++;
            }
            ConsoleTexts.WriteMenuConsoleTexts("GAMES LIST", listItems);
        }
    }
}
