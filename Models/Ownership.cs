using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestTask.Models
{
    public class Ownership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public OwnershipType Type { get; set; }
        public DateTime Date { get; set; }
        public double InitialPrice { get; set; }
        public Period LPPeriod { get; set; }
        public double LossPricePerPeriod { get; set; }

        [NotMapped]
        public double CurrentPrice
        {
            get 
            {
                var Periodes = (DateTime.Now - Date).Days / (int)LPPeriod;
                var curPrice = InitialPrice - (InitialPrice / 100 * LossPricePerPeriod * Periodes);
                if (curPrice > 0)
                    return curPrice;
                else
                    return 0;
            }
        }
    }

    public enum Period
    {
        Daily = 1,
        Weekly = 7,
        Monthly = 30,
        Yearly = 364
    }

    public enum OwnershipType
    {
        House = 0,
        Flat = 1,
        Car = 2
    }
}
