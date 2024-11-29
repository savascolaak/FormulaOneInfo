using FormulaOneInfo.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Concrete
{
    public class Season:EntityBase,IEntity
    {
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        //public ICollection<Pilot> Pilots { get; set; }
        public ICollection<GrandPrix> GrandPrixes { get; set; }
        //public ICollection<Team> Teams { get; set; }
        //public ICollection<Result> Results { get; set; }
    }
}
