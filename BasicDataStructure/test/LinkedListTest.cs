using src;
using Xunit;
using FluentAssertions;

namespace test
{
  public class LinkedListTest
  {
    [Fact]
    public void Add_GivenEmptyList_ExpectHeadWithData()
    {
      //Given
      var expected = new LinkedList
      {
        Head = new Node(1)
      };
      var actual = new LinkedList();

      //When
      actual.Add(1);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Add_GivenOneElementList_ExpectASecondNode()
    {
      //Given
      var expected = new LinkedList
      {
        Head = new Node(0)
      };
      expected.Head.Next = new Node(1);

      var actual = new LinkedList { Head = new Node(0) };

      //When
      actual.Add(1);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Add_GivenNonEmptyList_ExpectNewNodeAtTheEnd()
    {
      //Given
      var expected = new LinkedList
      {
        Head = new Node(0)
      };
      expected.Head.Next = new Node(1);
      expected.Head.Next.Next = new Node(2);

      var actual = new LinkedList { Head = new Node(0) };

      //When
      actual.Add(1);
      actual.Add(2);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void InsertAtPositionZero_GivenEmptyList_ExpectSuccess()
    {
      //Given
      var expected = new LinkedList { Head = new Node(1) };
      var actual = new LinkedList();

      //When
      actual.Insert(1, 0);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void InsertAtPositionZero_GivenNonEmptyList_ExpectNewHead()
    {
      //Given
      var expected = new LinkedList { Head = new Node(0) };
      expected.Head.Next = new Node(1);
      var actual = new LinkedList { Head = new Node(1) };

      //When
      actual.Insert(0, 0);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Insert_GivenPositionGreaterThanListSize_ExpectException()
    {
      //Given
      var actual = new LinkedList();

      //When
      Assert.Throws<IndexOutOfBoundException>(() => actual.Insert(0, 1));
    }

    [Fact]
    public void Insert_GivenValidPosition_ExpectSuccess()
    {
      //Given
      var expected = new LinkedList { Head = new Node(0) };
      expected.Head.Next = new Node(1);
      expected.Head.Next.Next = new Node(2);
      var actual = new LinkedList { Head = new Node(0) };
      actual.Head.Next = new Node(2);

      //When
      actual.Insert(1, 1);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }
  }
}