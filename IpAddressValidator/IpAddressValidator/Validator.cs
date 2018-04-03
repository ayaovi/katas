namespace IpAddressValidator
{
  public class Validator
  {
    public static bool ValidateIpv4Address(string value)
    {
      var bytes = value.Split('.');
      if (bytes.Length != 4) return false;
      if (bytes[3] == "0" || bytes[3] == "255") return false;
      return true;
    }
  }
}
