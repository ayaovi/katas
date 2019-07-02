using System;

namespace src
{
  public class IndexOutOfBoundException : Exception
  {
    public IndexOutOfBoundException(string message) : base(message) { }
  }

  public class LinkedList
  {
    public Node Head { get; set; }
    public LinkedList() { }

    public int Size()
    {
      var size = 0;
      var current = Head;
      while (current != null)
      {
        current = current.Next;
        size++;
      }
      return size;
    }

    public void Add(int value)
    {
      if (Head == null) Head = new Node(value);
      else
      {
        var current = Head;
        while (current.Next != null) { current = current.Next; }
        current.Next = new Node(value);
      }
    }

    public void Insert(int value, int position)
    {
      var size = Size();
      if (position > size) throw new IndexOutOfBoundException($"postion: {position} is greater than size :{size} of list.");
      if (Head == null) Head = new Node(value);
      else
      {
        var node = new Node(value);
        if (position == 0)
        {
          node.Next = Head;
          Head = node;
        }
        else
        {
          var current = Head;
          for (var i = 0; i < position - 1; i++)
          {
            current = current.Next;
          }
          node.Next = current.Next;
          current.Next = node;
        }
      }
    }
  }
}