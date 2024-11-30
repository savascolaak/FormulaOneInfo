using FormulaOneInfo.Entities.Concrete;
using FormulaOneInfo.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Entities.Dtos.SeasonDtos
{
    public class SeasonDto:DtoGetBase
    {
        public Season Season { get; set; }
    }
}
