using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proje3
{
    internal class Program
    {
        Random rand = new Random();
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            
            Random rand = new Random();
            
            //programda kullanmak icin Mahalle, Menu, Fiyat listeleri olusturuluyor
            string[] MahalleListesi = {"Evka 3", "Özkanlar", "Atatürk", "Erzene", "Kazımdirik"};
            
            string[] Menu = {"Doner","Pizza","Kebap","Karniyarik","Pilav","Corba","Lahmacun","Makarna",
                "Manti","Pide","Turlu","Kofte","Hamburger"};
            int[] fiyatlar = { 33,39,59,25,15,22,42,16,30,25,32,45,40};

            //agac nesnesi olusturularak her bir dugumune mahalle nesnesi ekleniyor. Mahalle nesnesi isim ve siparisleri tutan Arraylistden olusuyor
            //Arraylist - elemanlari Yemek sinifi nesneleri kendinde tutan generic listeden olusuyor
            Tree agac = new Tree();

            foreach (string mahalle in MahalleListesi)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < rand.Next(5,11); i++)
                {
                    List<Yemek> yemekler = new List<Yemek>(); 

                    for (int j = 0; j < rand.Next(3,6); j++)
                    {
                        int random = rand.Next(0, Menu.Length);
                        Yemek yemek = new Yemek(Menu[random],rand.Next(1,9),fiyatlar[random]);
                        yemekler.Add(yemek);
                    }
                    
                    array.Add(yemekler);

                }

                //mahalle nesnesi olusturarak agaca ekleniyor
                Mahalle mahalleler = new Mahalle(mahalle,array);
                agac.insert(mahalleler);
            }
            
            //mahalle ismine gore sirali olacak sekilde agacin tum dugumlerindeki bilgiler ekrana yazdiriliyor
            agac.inOrder(agac.getRoot());
            //agacin derinligi Tree sinfindaki metot ile bulunarak ekrana yazdiriliyor
            Console.WriteLine("\nAğacın Derinliği: " +agac.Depth(agac.getRoot())+ "\n" );

            //kullanicidan mahalle ismi sorularak, 150 tl uzerindeki siparis bilgileri ekrana tazdiriliyor
            Console.WriteLine("150TL üstündeki siparış bilgilerini listelemek istediğiniz mahalle ismini giriniz: ");
            string mahalleIsmi = Console.ReadLine();
            agac.yuksekFiyatliSiparis(mahalleIsmi);
            
            //kullanicidan yemek ismi sorularak, o yemegin toplam sioaris sayi ekrana yazilarak fiyatinda %10 indirim yapiliyor
            Console.WriteLine("\nMenüden bakarak sipariş sayını bulmak istediğiniz bir yemek ismi giriniz:");
            string yemekIsmi = Console.ReadLine();
            int say =agac.findYemek(agac.getRoot(),yemekIsmi);

            Console.WriteLine(yemekIsmi +" için toplam sipariş sayı: " +say );

            //Hash tablosuna eleman eklemek icin liste olusturuluyor
            string[] HashTable =
            {
                "Erzene, 35135", "Kazımdirik, 33934", "Atatürk, 28912", "Evka3, 20445", "Mevlana, 25492",
                "Yeşilova, 31008", "İnönü, 25778", "Doğanlar, 21461", "Rafet Paşa, 19476", "Kızılay, 15795"
            };
            
            //hashtable olusturarak key'i mahalle ismi, value'si nufus sayisi olacak sekilde hast tablosuna ekleme yapiliyor
            Hashtable ht = new Hashtable();

            foreach (string mahalleBilgisi in HashTable)
            {
                string key = mahalleBilgisi.Split(',')[0];
                int value = Int32.Parse(mahalleBilgisi.Split(',')[1]);
                ht.Add(key,value);
            }

            //kullanicidan karakter sorulrak, o harfle baslayan mahallelerin nufusuna 1 eklenerek guncelleniyor
            //guncellem metotunun aciklanmasi asagida yazilmistir
            Console.WriteLine("\nToplam nüfusuna 1 eklemek istediginiz mahallelerin baş harfini girin: ");
            string basHarf = Console.ReadLine();
            char harf = char.Parse(basHarf);
            
          hashTableGuncelle(ht,harf);

          
          //hazir heap veri yapisi kullanilarak nesnesi olusturuluyor ve nufusa gore oncelikli mahalle bilgileri ekleniyor
          Heap heap = new Heap(HashTable.Length);

          foreach (string mahalle in HashTable)
          {
              heap.insert(mahalle);
          }
          
          //nufusu en cok olan 3 mahalle heap'ten cekiliyor yani sirasiyla kokte duran eleman heap'ten cikartilarak siliniyor
          Console.WriteLine("\nNüfusu en fazla olan 3 mahallenin sıra ile Heap’ten çekilmesi: ");
          
         heap.remove();
         heap.remove();
         heap.remove();
          

        }

        //bas harfi verilen mahallenin nufusuna 1 ekleme metotu
        public static void hashTableGuncelle(Hashtable ht, char harf)
        {
            //ilk once hash tablosundaki elemanlar listeye ataniyor.
            //Eger bunu yapmazsak foreach dongusuyle hash tablosundaki degerleri degistirdigimiz zaman hata aliriz
            //daha sonra listedeki her bir eleman icin hash tablosundaki uygun anahtardaki degere 1 ekliyoruz.
            List<string> keys = new List<string>();
            foreach (DictionaryEntry de in ht)
                keys.Add(de.Key.ToString());

            foreach(string key in keys)
            {
                if (key[0].Equals(harf))
                {
                    
                    ht[key] = ht[key].GetHashCode()+1;
                    Console.WriteLine(key + ": " +ht[key]);    
                }
                
            }
            
        }
        
    }
}