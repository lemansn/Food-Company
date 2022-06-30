
using System;
using System.Collections.Generic;

namespace Proje3
{
    //TreeNode sinifi mahalle sinifinda datani, sag ve sol cocuklari degisken olarak aliyor. display() metotu ile agacin
    //dugumlerindeki tum bilgileri ekrana yazdiriyor.
    public class TreeNode
    {
        
            public Mahalle data;
            public TreeNode leftChild;
            public TreeNode rightChild;

            public void displayNode()
            {
                Console.WriteLine("\n" +data.MahalleAdi + " Mahallesi:\n");
                int teslimat =1;
                
                foreach (List<Yemek> list in data.liste)
                {
                    Console.WriteLine("--------------------------");

                    Console.WriteLine(teslimat +".Sipariş:");
                    foreach (Yemek yemek in list)
                    {
                        Console.WriteLine(yemek.YemekAdi+"- Adet:" + yemek.yemekAdeti + " Fiyat:" + yemek.yemekFiyati +" TL");
 
                    }
                    
                    teslimat++;
                }
                Console.WriteLine("---------------------------------------------------------");
            }
        

    }
}