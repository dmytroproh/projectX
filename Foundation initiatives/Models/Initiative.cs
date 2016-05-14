using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation_initiatives.Models
{
    public class Initiative
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser Director { get; set; }
        public ICollection<Step> Steps { get; set; }



        public Initiative()
        {
            Steps = new List<Step>();
        }
    }
}
