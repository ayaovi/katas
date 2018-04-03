using IpAddressValidator;
using NUnit.Framework;

namespace TestIpAddressValidator
{
  [TestFixture]
  public class IpAddressValidatorTests
  {
    [Test]
    public void ValidateIpv4Address_GivenEmptyString_ExpectFalse()
    {
      //Arrange && Act && Assert
      Assert.IsFalse(Validator.ValidateIpv4Address(string.Empty));
    }

    [TestCase("123")]
    [TestCase("123.11")]
    [TestCase("123.23.11")]
    public void ValidateIpv4Address_GivenAnythingOtherThan32BitString_ExpectFalse(string ip)
    {
      //Arrange && Act && Assert
      Assert.IsFalse(Validator.ValidateIpv4Address(ip));
    }

    [TestCase("123.0.0.0")]
    [TestCase("123.11.88.0")]
    [TestCase("123.23.11.0")]
    public void ValidateIpv4Address_GivenAnyAddressEndingInZero_ExpectFalse(string ip)
    {
      //Arrange && Act && Assert
      Assert.IsFalse(Validator.ValidateIpv4Address(ip));
    }

    [TestCase("123.0.0.255")]
    [TestCase("123.11.88.255")]
    [TestCase("123.23.11.255")]
    public void ValidateIpv4Address_GivenAnyAddressEndingIn255_ExpectFalse(string ip)
    {
      //Arrange && Act && Assert
      Assert.IsFalse(Validator.ValidateIpv4Address(ip));
    }

    [TestCase("192.168.1.1")]
    [TestCase("10.0.0.1 ")]
    [TestCase("127.0.0.1 ")]
    public void ValidateIpv4Address_GivenValidIpAddress_ExpectTrue(string ip)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(Validator.ValidateIpv4Address(ip));
    }
  }
}
