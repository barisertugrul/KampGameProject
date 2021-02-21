using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Concrete
{
    public class OrderManager : BaseTableOperationsManager<Order>
    {
        private IDbAdapterService<Order> _dbService;
        public OrderManager(IDbAdapterService<Order> dbService) : base(dbService)
        {
            _dbService = dbService;

            //Örnek Liste
        }

        public List<Order> OrdersOfGamer(int gamerId)
        {
            List<Order> ordersList = _dbService.GetList().Where(o => o.GamerId == gamerId).ToList();
            return ordersList;
        }

        public override void ConsoleMenu()
        {
            string[] menuItems = new string[] { "1-Add New Order", "2-Update Order", "3-Delete Order", "4-Order List", "5-Return MAIN MENU" };
            string val;
            int selected;

            ConsoleTexts.WriteMenuConsoleTexts("CAMPAIGN MANAGER", menuItems);
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
            Order order = new Order();
            string line;
            string[] list;
            DateTime orderDate;
            List<Game> games = MainConsoleManager._gameManager.GetList();
            List<Gamer> gamers = MainConsoleManager._gamerManager.GetList();
            List<Campaign> campaigns = MainConsoleManager._campaignManager.GetList().Where(c => c.CampaignStart <= DateTime.Now && DateTime.Now <= c.CampaignEnd).ToList();

            Console.Write("\nType order date (dd.mm.YYYY): ");
            line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out orderDate))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }
            order.OrderDate = orderDate;

            list = new string[gamers.Count];
            int i = 0;
            foreach (var gamer in gamers)
            {
                list[i] = gamer.Id + "- " + gamer.FirstName + " " + gamer.LastName + " (" + gamer.NickName + ")";
                i++;
            }
            ConsoleTexts.WriteMenuConsoleTexts("GAMERS LIST", list);
            Console.Write("\nType gamer id: ");
            order.GamerId = Convert.ToInt32(Console.ReadLine());

            Add(order);

            //Sipariş ayrıntıları ekleniyor
            int orderIndex = LastIndex();
            list = new string[games.Count];
            i = 0;
            foreach (var game in games)
            {
                list[i] = game.GameId + "- " + game.GameName + " (" + game.GameUnitPrice + ")";
                i++;
            }


            string[] campaignList = new string[campaigns.Count];
            i = 0;
            foreach (var campaign in campaigns)
            {
                campaignList[i] = campaign.CampaignId + "- " + campaign.CampaignName + " (Discount: " + campaign.Discount + ")";
                i++;
            }

            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderId = orderIndex;

            while (line != "N") {
                ConsoleTexts.WriteMenuConsoleTexts("GAMES LIST", list);
                Console.Write("\nSelect game id to order: ");
                orderDetail.GameId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nType game unit price: ");
                orderDetail.UnitPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("\nType quantity: ");
                orderDetail.Quantity = Convert.ToInt32(Console.ReadLine());
                ConsoleTexts.WriteMenuConsoleTexts("CAMPAIGNS LIST", campaignList);
                Console.Write("\nSelect campaign id for order (or leave blank): ");
                line = Console.ReadLine();
                if(line != "")
                {
                    orderDetail.CampaignId = Convert.ToInt32(line);
                }
                MainConsoleManager._orderDetailManager.Add(orderDetail);
                Console.Write("\nDo you want to add other products to the order? (Y or N): ");
            }
        }

        public override void ConsoleUpdateForm()
        {
            Console.WriteLine("Sipariş ve sipariş detayları güncellemesi eklenecek"); ;
        }

        public override void ConsoleDeleteForm()
        {
            Console.WriteLine("Sipariş ve sipariş detayları silme eklenecek");
        }

        public override void ConsoleListView()
        {
            string[] listItems = new string[GetList().Count];
            int i = 0;
            //ConsoleTexts.Header("CAMPAIGNS LIST");
            foreach (Order orderItem in GetList())
            {
                Gamer gamer = MainConsoleManager._gamerManager.GetById(orderItem.GamerId);
                listItems[i] = "Id: " + orderItem.OrderId + "-" + gamer.FirstName + " " + gamer.LastName + " (" + gamer.NickName + ")";
                i++;
            }
            ConsoleTexts.WriteMenuConsoleTexts("ORDERS LIST", listItems);
        }
    }
}
