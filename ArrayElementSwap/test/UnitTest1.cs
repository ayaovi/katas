using src;
using Xunit;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void Swap_GivenArraysWithSwapableElement_ExpectTrue()
        {
            // Given
            var a = new []{1,2,3,4};
            var b = new []{2,3,4,5};
            //When & Then
            Assert.True(AES.Swap(a, b));
        }

        [Fact]
        public void Swap_GivenArraysWithoutSwapableElement_ExpectTrue()
        {
            //Given
            var a = new []{0,2,3,4};
            var b = new []{2,3,4,5};
            //When & Then
            Assert.False(AES.Swap(a, b));
        }
    }
}
