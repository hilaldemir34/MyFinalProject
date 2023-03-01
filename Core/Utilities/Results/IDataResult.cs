using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult//işlem sonucunu ve mesajı ıresult içeriyor ben bir daha tekrar etmemek için miras aldırdık

    {
        T Data { get; }//T türünde bir data da olacak.

       
    }
}
