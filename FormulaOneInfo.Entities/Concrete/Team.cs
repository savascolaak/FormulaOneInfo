using FormulaOneInfo.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Concrete
{
    public class Team:EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public DateTime StartedDate { get; set; }
        //public int SeasonId { get; set; }
        //public Season Season { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
