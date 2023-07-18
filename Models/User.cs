using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Number { get;  set; }
        public virtual List<Ownership> Ownerships { get; set; }

        [NotMapped]
        public double InitialCapital
        {
            get
            {
                var capital = 0.0;
                if(!Ownerships.IsNullOrEmpty())
                {
                    foreach (var ownership in Ownerships)
                    {
                        capital += ownership.InitialPrice;
                    }
                }
                if (capital > 0.0)
                    return capital;
                else return 0.0;
            }
        }

        [NotMapped]
        public double CurrentCapital
        {
            get
            {
                var capital = 0.0;
                if (!Ownerships.IsNullOrEmpty())
                {
                    foreach (var ownership in Ownerships)
                    {
                        capital += ownership.CurrentPrice;
                    }
                }
                if (capital > 0.0)
                    return capital;
                else return 0.0;
            }
        }
    }
}
