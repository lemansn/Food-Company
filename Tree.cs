using System;
using System.Collections.Generic;

namespace Proje3
{
    public class Tree
    {
        private TreeNode root;

        int esitlik = 0; 


        //yapilandirici metot
        public Tree()
        {
            root = null;
        }

        //koku donduren metot
        public TreeNode getRoot()
        {
            return root;
        }

        //agacin inOrder dolasilmasi metotu. Sol cocuk, kok, sag cocuk seklinde
        public void inOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                localRoot.displayNode();
                inOrder(localRoot.rightChild);
            }
        }

        //Eklenecek mahalle nesnesini parametre olarak alıyor
        //Parametre olarak gelen mahalle nesnesinin ismini,geçici olarak atanan node’un datasının
        //mahalle ismiyle karşılaştırarak uygun yere(sağ/sol çoçuğa) ekleme işlemi yapılıyor.
        public void insert(Mahalle newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newdata.MahalleAdi.CompareTo(current.data.MahalleAdi) < 0)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } 
            } 
        } 

        
        //Kullanıcı tarafından girilen mahalle ismini parametre olarak alan metot. Mahalle ismini ağacda bularak, her sipariş
         //için fiyat bilgilerini hesapliyor ve 150 tl üzeri olan siparişleri ekrana yazdırıyor.
        public void yuksekFiyatliSiparis(string mahalle)
        {
            TreeNode current = root;
            while (!current.data.MahalleAdi.Equals(mahalle)) 
            {
                if (mahalle.CompareTo(current.data.MahalleAdi) < 0) 
                    current = current.leftChild;
                else 
                    current = current.rightChild;
                if (current == null)
                    Console.WriteLine("bulunamadi"); 
            }

            Console.WriteLine(current.data.MahalleAdi +" mahallesinde 150TL üstündeki siparış bilgileri: \n");
            foreach (List<Yemek> listeler in current.data.liste)
            {
                double toplam = 0;
                foreach (Yemek yemek in listeler)
                {
                    toplam += yemek.yemekFiyati;
                }

                if (toplam > 150)
                {
                    foreach (Yemek yemek in listeler)
                    {
                        Console.WriteLine(yemek.YemekAdi+"- Adet:" + yemek.yemekAdeti + " Fiyat:" + yemek.yemekFiyati +" TL");

                    }

                    Console.WriteLine("-----------------------------------");
                }
                
            }
        }
        
        //Ağacın sağ ve sol düğümlerini dolaşarak derinliği artırıb sonuca ulaşıyor. Sağ ve sol childleri
        //dolaşırken Recursive kullanılmıştır.
        public int Depth(TreeNode node) 
        {
            if (node == null)
                return -1;
            else
            {
                int lDepth = Depth(node.leftChild);
                int rDepth = Depth(node.rightChild);

                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }

    
        //Parametre olarak gönderilen yemek ismini tüm agacı dolaşarak sayını bulduran ve yemek türüne tüm
        //listelerde %10 indirim yapan metot
        public int findYemek(TreeNode root,string yemek) 
        {
            if (root != null)
            {
                foreach (List<Yemek> listeler in root.data.liste)
                {

                    foreach (Yemek yemekTuru in listeler)
                    {
                        if (yemekTuru.YemekAdi.Equals(yemek))
                        {
                            esitlik+= yemekTuru.yemekAdeti;
                            yemekTuru.yemekFiyati = yemekTuru.yemekFiyati * 0.9;
                        }
                    }
                }
                findYemek(root.leftChild, yemek);
                findYemek(root.rightChild, yemek);
            }
            return esitlik;


        
        }
    }
}