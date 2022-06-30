namespace Proje3
{
    //siparis verilen yemegin ismi, adet ve fiyat degiskenlerinden olusan Yemek sinifi 
    public class Yemek
    {
        public string YemekAdi;

        public int yemekAdeti;
        public double yemekFiyati;

        public Yemek(string YemekAdi, int yemekAdeti, int yemekFiyati)
        {
            this.YemekAdi = YemekAdi;
            this.yemekAdeti = yemekAdeti;
            this.yemekFiyati = yemekFiyati;

        }

    }
}