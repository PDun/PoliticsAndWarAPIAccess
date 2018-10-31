using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class CityAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void CityAPITest()
    {
      Assert.DoesNotThrow(() => new CityAPI());
    }
    [Test()]
    public void CityAPIMainTest()
    {
      Assert.DoesNotThrow(() => new CityAPI(Environment.Main));
    }
    [Test()]
    public void CityAPITestTest()
    {
      Assert.DoesNotThrow(() => new CityAPI(Environment.Test));
    }
    [Test()]
    public void CityAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new CityAPI(mockRestService.Object));
    }
    [Test()]
    public void GetCityTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<City>();
      mockRestService.Setup(x => x.Get<City>(It.IsAny<string>())).Returns(Task.FromResult(item));
      var service = new CityAPI(mockRestService.Object);
      var result = service.GetCity(4124).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<City>(It.Is<string>(y => y == "/city/id=4124")));
    }
    [Test()]
    [Category("Integration")]
    public void GetCityIntegrationTest()
    {
      var sut = new CityAPI();
      var result = sut.GetCity(10618).Result;
      Assert.IsNotNull(result);
    }
  }
}