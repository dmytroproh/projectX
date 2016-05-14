using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation_initiatives.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public ApplicationUser StepDirector { get; set; }

        public virtual ICollection<ApplicationUser> Members { get; set; }


        public int InitiativeId { get; set; }
        public Initiative Initiative { get; set; }

        public Step()
        {
            Members = new List<ApplicationUser>();
        }
    }
}
