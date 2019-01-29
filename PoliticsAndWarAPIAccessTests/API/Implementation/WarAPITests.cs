using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class WarAPITests
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
    public void WarAPIMainTest()
    {
      Assert.DoesNotThrow(() => new WarAPI(Environment.Main));
    }
    [Test()]
    public void WarAPITestTest()
    {
      Assert.DoesNotThrow(() => new WarAPI(Environment.Test));
    }
    [Test()]
    public void WarAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new WarAPI(mockRestService.Object));
    }
    [Test()]
    public void GetWarTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<WarResponse>();
      mockRestService.Setup(x => x.Get<WarResponse>(It.IsAny<string>(), null)).Returns(Task.FromResult(item));
      var service = new WarAPI(mockRestService.Object);
      var result = service.GetWar(1).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<WarResponse>(It.Is<string>(y => y == "/war/1"), null));
    }
    [Test()]
    [Category("Integration")]
    public void GetWarIntegrationTest()
    {
      var sut = new WarAPI();
      var result = sut.GetWar(355250).Result;
      Assert.IsNotNull(result);
    }
  }
}