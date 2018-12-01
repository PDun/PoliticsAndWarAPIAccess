using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class WarAttackAPITests
  {
    WarAttackAPI warAttackAPI;
    [SetUp()]
    public void setup()
    {
      warAttackAPI = new WarAttackAPI();
    }
    [Test()]
    public void GetWarAttackTest()
    {
    }
  }
}