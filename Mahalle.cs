using System.Collections;
using System.Collections.Generic;

namespace Proje3
{
    //Mahalle sinifi degiskenleri mahalle ismi ve siparisleri tutmak icin Arraylistdir./
    public class Mahalle
    {
        public string MahalleAdi;
        public ArrayList liste { get;  }


        public Mahalle(string MahalleAdi,ArrayList liste)
        {
            this.MahalleAdi = MahalleAdi;
            this.liste = liste;

        }
    }
}