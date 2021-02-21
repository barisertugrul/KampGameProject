using KampGameProject.Abstract;
using System;

namespace KampGameProject.Entities
{
    public class Campaign:IEntity
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime CampaignStart { get; set; }
        public DateTime CampaignEnd { get; set; }
        public decimal Discount { get; set; }
    }
}
