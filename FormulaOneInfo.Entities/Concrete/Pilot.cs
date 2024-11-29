using FormulaOneInfo.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Concrete
{
    public class Pilot:EntityBase,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Thumbnail { get; set; }
        //public int SeasonId { get; set; }
        //public Season Season { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
