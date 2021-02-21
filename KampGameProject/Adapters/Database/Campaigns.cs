using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Adapters.Database
{
    public class Campaigns : IDbAdapterService<Campaign>
    {
        private List<Campaign> _campaigns;

        public Campaigns()
        {
            //Normalde Veritabanındaki veriler burada listeye ekleniyor
            //Aşağıdaki işlem veritabanının boş olması durumunu simgeliyor
            _campaigns = new List<Campaign>();
        }

        public void Add(Campaign campaign)
        {
            campaign.CampaignId = LastIndex() + 1;
            _campaigns.Add(campaign);
            Console.WriteLine("The campaign has been successfully added");
        }

        public void Delete(Campaign campaign)
        {
            Campaign currentCampaign = _campaigns.SingleOrDefault(c => c.CampaignId == campaign.CampaignId);
            _campaigns.Remove(currentCampaign);
        }

        public void Update(Campaign campaign)
        {
            Campaign currentCampaign = _campaigns.SingleOrDefault(c => c.CampaignId == campaign.CampaignId);
            currentCampaign.CampaignName = campaign.CampaignName;
            currentCampaign.CampaignStart = campaign.CampaignStart;
            currentCampaign.CampaignEnd = campaign.CampaignEnd;
            currentCampaign.Discount = campaign.Discount;
        }

        public List<Campaign> GetList()
        {
            return _campaigns;
        }

        public int LastIndex()
        {
            if (_campaigns.Count > 0)
            {
                Campaign campaign = _campaigns[_campaigns.Count - 1];
                return campaign.CampaignId;
            }
            else
            {
                return 0;
            }
        }

        public Campaign GetById(int campaignId)
        {
            return _campaigns.SingleOrDefault(c => c.CampaignId == campaignId);
        }
    }
}
