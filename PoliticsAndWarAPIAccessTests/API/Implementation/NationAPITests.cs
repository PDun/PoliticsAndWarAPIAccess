using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class NationAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void NationAPITest()
    {
      Assert.DoesNotThrow(() => new NationAPI());
    }
    [Test()]
    public void NationAPIMainTest()
    {
      Assert.DoesNotThrow(() => new NationAPI(Environment.Main));
    }
    [Test()]
    public void NationAPITestTest()
    {
      Assert.DoesNotThrow(() => new NationAPI(Environment.Test));
    }
    [Test()]
    public void NationAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new NationAPI(mockRestService.Object));
    }
    [Test()]
    public void GetNationTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<Nation>();
      mockRestService.Setup(x => x.Get<Nation>(It.IsAny<string>(), null)).Returns(Task.FromResult(item));
      var service = new NationAPI(mockRestService.Object);
      var result = service.GetNation(4124).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<Nation>(It.Is<string>(y => y == "/nation/id=4124"), null));
    }
    [Test()]
    [Category("Integration")]
    public void GetNationIntegrationTest()
    {
      var sut = new NationAPI();
      var result = sut.GetNation(6).Result;
      Assert.IsNotNull(result);
    }
  }
}