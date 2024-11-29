using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.PilotDtos
{
    public class PilotListDto:DtoGetBase
    {
        public IList<Pilot> Pilots { get; set; }
    }
}
