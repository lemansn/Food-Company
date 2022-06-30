using System;

namespace Proje3
{
   public class Node
   {
      private string iData; 
      public Node(string key)
      {
         iData = key;
      }

      public string getKey()
      {
         return iData;
      }
      
   }

   public class Heap
   {
      private Node[] heapArray; //elemanlari tutmak icin Node sinifi tipinde liste degiskeni
      private int maxSize; 
      private int currentSize; 

      public Heap(int mx) //yapilandirici metot
      {
         maxSize = mx;
         currentSize = 0;
         heapArray = new Node[maxSize]; 
      }

      //Heap e eleman ekleme metotu
      public bool insert(string key)
      {
         if (currentSize == maxSize)
            return false;
         Node newNode = new Node(key);
         heapArray[currentSize] = newNode;
         trickleUp(currentSize++);
         return true;
      } // end insert()

      //Max heap kurallarina uygun olarak nufus oncelikli eleman ekleme icin damlama metotu
      public void trickleUp(int index)
      {
         int parent = (index - 1) / 2;
         Node bottom = heapArray[index];

         while (index > 0 &&
                heapArray[parent].getKey().Split(',')[1].CompareTo(bottom.getKey().Split(',')[1]) < 0)
         {
            heapArray[index] = heapArray[parent];
            index = parent;
            parent = (parent - 1) / 2;
         }

         heapArray[index] = bottom;
      }
      
      
      //heap den eleman silme metotu, kokdeki elemani siliyor
      public void remove()
      {
         Node root = heapArray[0];
         heapArray[0] = heapArray[--currentSize];
         trickleDown(0);
         Console.WriteLine(root.getKey());
      } 

      //max heap kurallarini bozmadan kokteki elemani sildikten sonra nufus sayisini gore heap yapisini guncelliyor
      public void trickleDown(int index)
      {
         int largerChild;
         Node top = heapArray[index]; 
         while (index < currentSize / 2) 
         {
            int leftChild = 2 * index + 1;
            int rightChild = leftChild + 1;
            
            if (rightChild < currentSize && 
                heapArray[leftChild].getKey().Split(',')[1].
                   CompareTo(heapArray[rightChild].getKey().Split(',')[1]) <0)

               largerChild = rightChild;
            else
               largerChild = leftChild;
            if (top.getKey().Split(',')[1].CompareTo(heapArray[largerChild].getKey().Split(',')[1]) >= 0)
               break;
            heapArray[index] = heapArray[largerChild];
            index = largerChild;
         }

         heapArray[index] = top; 
      } 

   }
}