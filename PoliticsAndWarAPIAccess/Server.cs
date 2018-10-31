namespace PoliticsAndWarAPIAccess
{
  public static class Server {
    public static string GetBaseUrl(Environment env)
    {
      switch (env) 
      {
        case Environment.Main:
          return @"https://politicsandwar.com/api/";
        case Environment.Test:
          return @"https://test.politicsandwar.com/api/";
      }
      return string.Empty;
    }
  }
  public enum Environment
  {
    Main,
    Test
  }
}
