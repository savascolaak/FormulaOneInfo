using FormulaOneInfo.Shared.Utilities.Result.Abstract;
using FormulaOneInfo.Shared.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Shared.Utilities.Result.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data)
        {
           
            Data = data;
        }
        public DataResult(ResultStatus resultStatus,T data)
        {
            Data = data;
            ResultStatus = resultStatus;
        }
        public DataResult(ResultStatus resultStatus, string message, T data) 
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
        }
        public DataResult(T data, string message, ResultStatus resultStatus,Exception exception)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }

        public T Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
