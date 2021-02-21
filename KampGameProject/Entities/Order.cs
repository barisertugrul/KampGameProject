using KampGameProject.Abstract;
using System;

namespace KampGameProject.Entities
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public int GamerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
