using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> //T için sen BİR Resultsın aynı zamanda IDataResultsın o T için
    {
        public DataResult(T data,bool success,string message):base(success,message)//base gönderdiğimiz bu iki kodu bir daha yazmayız.
        
        {
            Data = data;//datayı çağırdık
        }
        public DataResult(T data,bool success):base(success)//mesaj göndermek istemiyorsak bunu kullanırız.
        {
            Data = data;//data yı set ettik
        }

        public T Data { get; }
    }
}
