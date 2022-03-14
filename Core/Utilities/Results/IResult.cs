using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Succsess { get; } //bu bir property get ile sadece okuyacağım succsess başarılı mı değilmi mesajı. bool veri tipi true veya false değer
                                //alabilir. buda bizi işlem sonucu true ise başarılı false ise başarısız a götürür. 
        string Message { get; }  //message ise yapmaya çalıştığın iş başarılı ise ürün eklendi gibibir mesaj yada eklenmediyse bu yüzden eklenmedi.
    }
}
