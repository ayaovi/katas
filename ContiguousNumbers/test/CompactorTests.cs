using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using src;
using Xunit;

namespace test {
    public class CompactorTests {
        [Fact]
        public void Reduce_GivenEmptyArray_ExpectEmptyArray () {
            //Given
            var expected = Enumerable.Empty<int> ().ToArray ();
            var x = Enumerable.Empty<int> ().ToArray ();

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Reduce_GivenArrayOfOneElement_ExpectArrayOfOneElement () {
            //Given
            var expected = new [] { 1 };
            var x = new [] { 1 };

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Reduce_GivenArrayOfTwoElements_ExpectArrayOfTwoElements () {
            //Given
            var expected = new [] { 1, 2 };
            var x = new [] { 1, 2 };

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Reduce_GivenArrayOfThreeContiguousNumbers_ExpectArrayOfTwoElements () {
            //Given
            var expected = new [] { 1, 3 };
            var x = new [] { 1, 2, 3 };

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Reduce_GivenArrayOfFourContiguousNumbers_ExpectArrayOfTwoElements () {
            //Given
            var expected = new [] { 1, 4 };
            var x = new [] { 1, 2, 3, 4 };

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Reduce_GivenArrayOfThreeContiguousNumbers_ExpectArrayOfTwoElements1 () {
            //Given
            var expected = new [] { 1, 4, 6, 7 };
            var x = new [] { 1, 2, 3, 4, 6, 7 };

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Reduce_GivenArrayOfThreeContiguousNumbers_ExpectArrayOfTwoElements2 () {
            //Given
            var expected = new [] { 1, 4, 6, 8, 11 };
            var x = new [] { 1, 2, 3, 4, 6, 7, 8, 11 };

            //When
            var actual = x.Reduce ();

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }
    }
}