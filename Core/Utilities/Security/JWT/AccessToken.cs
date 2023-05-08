using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken//erişim anahtarı
    {
        public string Token { get; set; }//jwt nin ta kendisi.api üzerinden kullanıcı adı ve parola vericek biz de ona token vericez.
        public DateTime Expiration { get; set; }//ne zaman sonlanacağının bilgisini vereceğiz.
    }
}
