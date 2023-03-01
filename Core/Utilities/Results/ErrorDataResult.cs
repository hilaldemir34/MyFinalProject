using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
 
        public class ErrorDataResult<T> : DataResult<T>
        {
            public ErrorDataResult(T data, string message) : base(data, false, message)
            {

            }
            public ErrorDataResult(T data) : base(data, false)//mesaj göndermek istemiyorsan bunu yaz
            {

            }
            public ErrorDataResult(string message) : base(default, false, message)//datayı default haliyle döndür
            {

            }
            public ErrorDataResult() : base(default, false)
            {

            }
        }
  
}
