using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALibraryProject
{
    public class Yazar : BaseModel
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string FulAd
        {
            get
            { return Ad + " " + Soyad; }

            set { ; }
         }
        public bool Cinsiyet { get; set; }


    }
}
