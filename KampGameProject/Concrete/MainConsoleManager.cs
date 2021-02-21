using KampGameProject.Adapters;
using KampGameProject.Adapters.Database;
using KampGameProject.Entities;
using System;

namespace KampGameProject.Concrete
{
    public static class MainConsoleManager
    {
        /****************************************************************************
         * 
         * Console işlemleri merkezi
         * Uygulamanın pek çok eksiği var, veri girişi ve doğrulama alanlarında mesela
         * Ama ödev için gerekli ana işlevleri karşılıyor olmalı
         * 
         ***************************************************************************/

        public static Gamers _gamersDb;
        public static GamerManager _gamerManager;
        public static Games _gamesDb;
        public static GameManager _gameManager;
        public static Campaigns _campaignsDb;
        public static CampaignManager _campaignManager;
        public static Orders _ordersDb;
        public static OrderManager _orderManager;
        public static OrderDetails _orderDetailsDb;
        public static OrderDetailManager _orderDetailManager;
        public static bool VerificationActive = false;

        static MainConsoleManager()
        {
            _gamersDb = new Gamers();
            _gamerManager = new GamerManager(_gamersDb, new MernisServiceAdapter());
            _gamesDb = new Games();
            _gameManager = new GameManager(_gamesDb);
            _campaignsDb = new Campaigns();
            _campaignManager = new CampaignManager(_campaignsDb);
            _ordersDb = new Orders();
            _orderManager = new OrderManager(_ordersDb);
            _orderDetailsDb = new OrderDetails();
            _orderDetailManager = new OrderDetailManager(_orderDetailsDb);
            ExampleDatas();
        }

        public static void MainMenu()
        {
            string[] menuItems = new string[] { "1-Game Manager", "2-User Manager", "3-Campaign Manager", "4-Order Manager", "5-EXIT" };
            ConsoleTexts.WriteMenuConsoleTexts("MAIN MENU", menuItems);
            Console.Write("\nSelect number of menu item: ");
            string val;
            val = Console.ReadLine();
            int selected = Convert.ToInt32(val);
            switch (selected)
            {
                case 1:
                    GameMenu();
                    break;
                case 2:
                    GamerMenu();
                    break;
                case 3:
                    CampaignMenu();
                    break;
                case 4:
                    OrderMenu();
                    MainMenu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You made the wrong choice. Please try again.");
                    MainMenu();
                    break;
            }
        }

        private static void GameMenu()
        {
            _gameManager.ConsoleMenu();
        }

        private static void GamerMenu()
        {
            _gamerManager.ConsoleMenu();
        }

        private static void CampaignMenu()
        {
            _campaignManager.ConsoleMenu();
        }

        private static void OrderMenu()
        {
            _orderManager.ConsoleMenu();
        }

        private static void ExampleDatas()
        {
            _gamerManager.Add(new Gamer()
            {
                DateOfBirth = new DateTime(1870, 2, 7),
                FirstName = "Alfred",
                LastName = "Adler",
                NationalityId = "25846731942",
                NickName = "Alf"
            });
            _gamerManager.Add(new Gamer()
            {
                DateOfBirth = new DateTime(1856, 7, 10),
                FirstName = "Nikola",
                LastName = "Tesla",
                NationalityId = "35971564217",
                NickName = "Niko"
            });
            _gamerManager.Add(new Gamer()
            {
                DateOfBirth = new DateTime(1828, 2, 8),
                FirstName = "Jules",
                LastName = "Verne",
                NationalityId = "48219375638",
                NickName = "Science Fiction"
            });
            _gameManager.Add(new Game()
            {
                GameName = "Super Marıo",
                GameUnitPrice = 25,
                GameUnitsInStock = 125
            });
            _gameManager.Add(new Game()
            {
                GameName = "PubG Mobile",
                GameUnitPrice = 540,
                GameUnitsInStock = 38
            });
            _campaignManager.Add(new Campaign()
            {
                CampaignName = "Zemheri Kampanyası",
                CampaignStart = new DateTime(2021, 02, 18),
                CampaignEnd = new DateTime(2021, 03, 18),
                Discount = 18
            });
            _campaignManager.Add(new Campaign()
            {
                CampaignName = "Merhaba Bahar",
                CampaignStart = new DateTime(2021, 03, 01),
                CampaignEnd = new DateTime(2021, 05, 15),
                Discount = 10
            });
            _campaignManager.Add(new Campaign()
            {
                CampaignName = "Oyunsever Kadınlar - 8 Mart Kampanyası",
                CampaignStart = new DateTime(2021, 03, 08),
                CampaignEnd = new DateTime(2021, 03, 15),
                Discount = 50
            });
            VerificationActive = true;
        }
    }
}
