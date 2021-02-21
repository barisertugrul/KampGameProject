using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Concrete
{
    public class GamerManager : BaseTableOperationsManager<Gamer>
    {
        //private List<Game> games;
        private IUserValidationService _userValidationService;

        public GamerManager(IDbAdapterService<Gamer> dbService, IUserValidationService userValidationService): base(dbService)
        {
            //_userValidationService = userValidationService;
        }
        public override void Add(Gamer gamer)
        {

            if (MainConsoleManager.VerificationActive)
            {
                if (_userValidationService.Validate(gamer))
                {
                    base.Add(gamer);
                }
                else
                {
                    throw new Exception("Not a valid person");
                }
            }
            else
            {
                base.Add(gamer);
            }
        }

        public override void ConsoleMenu()
        {
            string[] menuItems = new string[] { "1-Add New Gamer", "2-Update Gamer", "3-Delete Gamer", "4-Gamers List", "5-Return MAIN MENU" };
            string val;
            int selected;

            ConsoleTexts.WriteMenuConsoleTexts("GAMER MANAGER", menuItems);
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
            Gamer gamer = new Gamer();
            string line;
            DateTime bDay;

            Console.Write("\nType first name: ");
            gamer.FirstName = Console.ReadLine();
            Console.Write("\nType last name: ");
            gamer.LastName = Console.ReadLine();
            Console.Write("\nType gamer nick name: ");
            gamer.NickName = Console.ReadLine();
            Console.Write("\nType date of birth (dd.mm.YYYY): ");
            line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out bDay))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }
            gamer.DateOfBirth = bDay;
            Console.Write("\nType nationality ID: ");
            gamer.NationalityId = Console.ReadLine();
            Add(gamer);
        }

        public override void ConsoleUpdateForm()
        {
            Gamer gamer = new Gamer();
            string firstName;
            string lastName;
            string nName;
            string line;
            string nId;
            DateTime bDay;

            ConsoleListView();
            Console.Write("\nEnter the Id of the gamer to be updated: ");
            gamer.Id = Convert.ToInt32(Console.ReadLine());
            gamer = GetById(gamer.Id);
            Console.Write("\nType new first name (Leave blank if you do not want to change): ");
            firstName = Console.ReadLine();
            if (firstName != "") gamer.FirstName = firstName;
            Console.Write("\nType new last name (Leave blank if you do not want to change): ");
            lastName = Console.ReadLine();
            if (lastName != "") gamer.LastName = lastName;
            Console.Write("\nType new nick name (Leave blank if you do not want to change): ");
            nName = Console.ReadLine();
            if (nName != "") gamer.NickName = nName;
            Console.Write("\nType new birth date (dd.mm.yyyy) (Leave blank if you do not want to change): ");
            line = Console.ReadLine();
            if (line != "")
            {
                while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out bDay))
                {
                    Console.WriteLine("Invalid date, please retry");
                    line = Console.ReadLine();
                }
                gamer.DateOfBirth = bDay;
            }

            Console.Write("\nType new nationality ID (Leave blank if you do not want to change): ");
            nId = Console.ReadLine();
            if (nId != "") gamer.NationalityId = nId;
            Update(gamer);
        }

        public override void ConsoleDeleteForm()
        {
            Gamer gamer = new Gamer();

            ConsoleListView();
            Console.Write("\nEnter the Id of the gamer to be removed: ");
            gamer.Id = Convert.ToInt32(Console.ReadLine());
            Delete(gamer);
        }

        public override void ConsoleListView()
        {
            string[] listItems = new string[GetList().Count];
            int i = 0;
            foreach (Gamer gamerItem in GetList())
            {
                listItems[i] = "Id: " + gamerItem.Id + "-" + gamerItem.FirstName + " " + gamerItem.LastName + " (Nick: " + gamerItem.NickName + ")";
                i++;
            }
            ConsoleTexts.WriteMenuConsoleTexts("GAMERS LIST", listItems);
        }

        public List<Game> GetOwnGameList(Gamer gamer)
        {
            List<Order> ordersList = MainConsoleManager._orderManager.OrdersOfGamer(gamer.Id);
            List<Game> gamesList = new List<Game>();
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            Game game;
            foreach (Order order in ordersList)
            {
                orderDetails = MainConsoleManager._orderDetailManager.DetailsOfOrder(order.OrderId);
                foreach (OrderDetail orderDetail in orderDetails)
                {
                    game = MainConsoleManager._gameManager.GetById(orderDetail.GameId);
                    Game result = gamesList.SingleOrDefault(g => g.GameId == game.GameId);
                    if (result == null)
                    {
                        gamesList.Add(game);
                    }
                }

            }
            return gamesList;
        }
    }
}
