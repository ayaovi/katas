using FluentAssertions;
using src;
using Xunit;

namespace test {
  public class UtilitiesTest {
    [Fact]
    public void RemoveDuplicates_GivenListWithoutDuplicates_ExpectSuccess () {
      //Given
      var expected = new LinkedList();
      expected.Head = new Node(0);
      expected.Head.Next = new Node(1);
      expected.Head.Next.Next = new Node(2);
      expected.Head.Next.Next.Next = new Node(3);

      var list = new LinkedList();
      list.Head = new Node(0);
      list.Head.Next = new Node(1);
      list.Head.Next.Next = new Node(2);
      list.Head.Next.Next.Next = new Node(3);

      //When
      var actual = Utilities.RemoveDuplicates(list);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void RemoveDuplicates_GivenListWithDuplicates_ExpectSuccess () {
      //Given
      var expected = new LinkedList();
      expected.Head = new Node(0);
      expected.Head.Next = new Node(1);
      expected.Head.Next.Next = new Node(2);
      expected.Head.Next.Next.Next = new Node(3);

      var list = new LinkedList();
      list.Head = new Node(0);
      list.Head.Next = new Node(1);
      list.Head.Next.Next = new Node(2);
      list.Head.Next.Next.Next = new Node(2);
      list.Head.Next.Next.Next.Next = new Node(3);

      //When
      var actual = Utilities.RemoveDuplicates(list);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }
  }
}