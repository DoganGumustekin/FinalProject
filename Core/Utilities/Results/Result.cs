using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success) //get ler read only dir ve constructor da set edilebilir. 
        {                                           //ben constructor dışında set etmeyeceğim için property me sadece get diyorum.
            Message = message;                 //iki parametre verdiğimde bu ctor çalışacak ve this(success) ile alttaki ctoru da 
        }                                      //kapsıyorum. burada ya sadece true gibi yada true+message gibi bir mesaj gönderebilirsin.

        public Result(bool succsess)
        {
            Succsess = succsess;
        }


        public bool Succsess { get; }
        public string Message { get; }
    }
}
