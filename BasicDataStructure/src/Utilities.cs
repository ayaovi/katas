using System;

namespace src
{
  public static class Utilities
  {
    public static LinkedList RemoveDuplicates(LinkedList list)
    {
      var pointer1 = list.Head;
      var pointer2 = list.Head.Next;

      while (pointer2 != null)
      {
        if (pointer1.Data != pointer2.Data) {
          pointer1.Next = pointer2;
          pointer1 = pointer2;
        }
        pointer2 = pointer2.Next;
      }
      
      return list;
    }
  }
}