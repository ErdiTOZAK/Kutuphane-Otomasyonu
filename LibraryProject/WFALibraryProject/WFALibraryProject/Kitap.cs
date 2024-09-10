using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALibraryProject
{
    public class Kitap:BaseModel
    {
        public string Ad {  get; set; }

        public string Tur { get; set; }

        public DateTime BasimYili { get; set; }

       // public virtual Yazar Yazar { get; set; }

        public string YazarId { get; set; }

    }
}
