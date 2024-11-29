using FormulaOneInfo.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Concrete
{
    public class GrandPrix:EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Track { get; set; }
        public string Country { get; set; } 
        public string City { get; set; }
        public DateTime GrandPrixDate { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
