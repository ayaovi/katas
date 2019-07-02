using FluentAssertions;
using src;
using Xunit;

namespace test {
  public class UtilitiesTest {
    [Fact]
    public void RemoveDuplicates_GivenListWithoutDuplicates_ExpectSuccess () {
      //Given
      var expected = new LinkedList ();
      expected.Head = new Node (0);
      expected.Head.Next = new Node (1);
      expected.Head.Next.Next = new Node (2);
      expected.Head.Next.Next.Next = new Node (3);

      var list = new LinkedList ();
      list.Head = new Node (0);
      list.Head.Next = new Node (1);
      list.Head.Next.Next = new Node (2);
      list.Head.Next.Next.Next = new Node (3);

      //When
      var actual = Utilities.RemoveDuplicates (list);

      //Then
      actual.Should ().BeEquivalentTo (expected);
    }

    [Fact]
    public void RemoveDuplicates_GivenListWithDuplicates_ExpectSuccess () {
      //Given
      var expected = new LinkedList ();
      expected.Head = new Node (0);
      expected.Head.Next = new Node (1);
      expected.Head.Next.Next = new Node (2);
      expected.Head.Next.Next.Next = new Node (3);

      var list = new LinkedList ();
      list.Head = new Node (0);
      list.Head.Next = new Node (1);
      list.Head.Next.Next = new Node (2);
      list.Head.Next.Next.Next = new Node (2);
      list.Head.Next.Next.Next.Next = new Node (3);

      //When
      var actual = Utilities.RemoveDuplicates (list);

      //Then
      actual.Should ().BeEquivalentTo (expected);
    }

    [Fact]
    public void Merge_GivenTwoArrays_ExpectBiggerArray () {
      //Given
      var arr1 = new [] { 1, 2, 3 };
      var arr2 = new [] { 2, 4, 5 };
      var expected = new [] { 1, 2, 2, 3, 4, 5 };

      //When
      var actual = Utilities.Merge (arr1, arr2);

      //Then
      actual.Should ().BeEquivalentTo (expected);
    }

    [Fact]
    public void Merge_GivenTwoArrays_ExpectBiggerArray1 () {
      //Given
      var arr1 = new [] { 1, 3 };
      var arr2 = new [] { 2, 4, 5 };
      var expected = new [] { 1, 2, 3, 4, 5 };

      //When
      var actual = Utilities.Merge (arr1, arr2);

      //Then
      actual.Should ().BeEquivalentTo (expected);
    }

    [Fact]
    public void RangeCopy_GivenValidRange_ExpectSubArray () {
      //Given
      var arr = new [] { 1, 2, 3, 4, 5 };
      var expected = new [] { 2, 3, 4 };

      //When
      var actual = arr.RangeCopy (1, 3);

      //Then
      actual.Should ().BeEquivalentTo (expected);
    }

    [Fact]
    public void MergeSort_GivenUnsortedArray_ExpectSortedArray () {
      //Given
      var arr = new [] { 30, 8, 0, 21, 5, 2, 11 };
      var expected = new [] { 0, 2, 5, 8, 11, 21, 30 };

      //When
      var actual = arr.MergeSort(0, arr.Length - 1);

      //Then
      actual.Should().BeEquivalentTo(expected);
    }
  }
}