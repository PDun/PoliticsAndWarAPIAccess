using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class WarsAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void WarAPITest()
    {
      Assert.DoesNotThrow(() => new WarAPI());
    }
    [Test()]
    public void WarsAPIMainTest()
    {
      Assert.DoesNotThrow(() => new WarsAPI(Environment.Main));
    }
    [Test()]
    public void WarsAPITestTest()
    {
      Assert.DoesNotThrow(() => new WarsAPI(Environment.Test));
    }
    [Test()]
    public void WarsAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new WarsAPI(mockRestService.Object));
    }
  }
}