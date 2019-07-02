using System;

namespace src
{
  public class Node
  {
    public int Data { get; private set; }
    public Node Next { get; set; }

    public Node(int data)
    {
      Data = data;
    }
  }
}
