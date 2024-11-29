using FormulaOneInfo.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Concrete
{
    public class Result:EntityBase,IEntity
    {
        public int Order { get; set; } //Eğer 0 ise DNF
        public int Points { get; set; }
            //public int SeasonId { get; set; }
            //public Season Season { get; set; }
        public int GrandPrixId { get; set; }
        public GrandPrix GrandPrix { get; set; }
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        //public DateTime GrandPrixDate { get; set; }
    }
}
