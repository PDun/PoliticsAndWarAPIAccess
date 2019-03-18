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
    [Test()]
    public void GetWarsTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<WarsResponse>();
      mockRestService.Setup(x => x.Get<WarsResponse>(It.IsAny<string>(), null)).Returns(Task.FromResult(item));
      var service = new WarsAPI(mockRestService.Object);
      var result = service.GetWars(1,"test").Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<WarsResponse>(It.Is<string>(y => y == "/wars/1"), null));
    }
    [Test()]
    [Category("Integration")]
    public void GetWarsIntegrationTest()
    {
      var sut = new WarsAPI();
      var result = sut.GetWars(355250, "test").Result;
      Assert.IsNotNull(result);
    }
  }
}