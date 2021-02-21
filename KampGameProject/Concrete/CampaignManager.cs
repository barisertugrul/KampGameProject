using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;

namespace KampGameProject.Concrete
{
    public class CampaignManager : BaseTableOperationsManager<Campaign>
    {

        public CampaignManager(IDbAdapterService<Campaign> dbService) : base(dbService)
        {

        }

        public override void ConsoleMenu()
        {
            string[] menuItems = new string[] { "1-Add New Campaign", "2-Update Campaign", "3-Delete Campaign", "4-Campaigns List", "5-Return MAIN MENU" };
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
            Campaign campaign = new Campaign();
            string line;
            DateTime start;
            DateTime end;

            Console.Write("\nType campaign name: ");
            campaign.CampaignName = Console.ReadLine();

            Console.Write("\nType discount (%): ");
            campaign.Discount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("\nType campaign start date (dd.mm.YYYY): ");
            line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out start))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }
            campaign.CampaignStart = start;

            Console.Write("\nType campaign end date (dd.mm.YYYY): ");
            line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out end))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }
            campaign.CampaignEnd = end;

            Add(campaign);
        }

        public override void ConsoleUpdateForm()
        {
            Campaign campaign = new Campaign();
            string name;
            string discount;
            string line;
            DateTime start;
            DateTime end;

            ConsoleListView();
            Console.Write("\nEnter the Id of the campaign to be updated: ");
            campaign.CampaignId = Convert.ToInt32(Console.ReadLine());
            campaign = GetById(campaign.CampaignId);

            Console.Write("\nType new campaign name (Leave blank if you do not want to change): ");
            name = Console.ReadLine();
            if (name != "") campaign.CampaignName = name;

            Console.Write("\nType new discount (Leave blank if you do not want to change): ");
            discount = Console.ReadLine();
            if (discount != "") campaign.Discount = Convert.ToDecimal(discount);

            Console.Write("\nType new campaign start date (dd.mm.yyyy) (Leave blank if you do not want to change): ");
            line = Console.ReadLine();
            if (line != "")
            {
                while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out start))
                {
                    Console.WriteLine("Invalid date, please retry");
                    line = Console.ReadLine();
                }
                campaign.CampaignStart = start;
            }

            Console.Write("\nType new campaign end date (dd.mm.yyyy) (Leave blank if you do not want to change): ");
            line = Console.ReadLine();
            if (line != "")
            {
                while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out end))
                {
                    Console.WriteLine("Invalid date, please retry");
                    line = Console.ReadLine();
                }
                campaign.CampaignEnd = end;
            }

            Update(campaign);
        }

        public override void ConsoleDeleteForm()
        {
            ConsoleListView();
            Campaign campaign = new Campaign();
            Console.Write("\nEnter the Id of the campaign to be removed: ");
            campaign.CampaignId = Convert.ToInt32(Console.ReadLine());
            Delete(campaign);
        }

        public override void ConsoleListView()
        {
            string[] listItems = new string[GetList().Count];
            int i = 0;
            //ConsoleTexts.Header("CAMPAIGNS LIST");
            foreach (Campaign campaignItem in GetList())
            {
                listItems[i] = "Id: " + campaignItem.CampaignId + "-" + campaignItem.CampaignName + " (Discount: " + campaignItem.Discount + "%)";
                i++;
            }
            ConsoleTexts.WriteMenuConsoleTexts("CAMPAIGNS LIST", listItems);
        }
    }
}
