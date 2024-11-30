using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.ResultDtos
{
    public class ResultAddDto
    {
        public int Order { get; set; }
        public int Points { get; set; }
        public int GrandPrixId { get; set; }
        public int PilotId { get; set; }
        public int TeamId { get; set; }
        public bool IsActive { get; set; }

    }
}
