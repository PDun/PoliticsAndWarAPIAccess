using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class TradePriceAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void TradePriceAPITest()
    {
      Assert.DoesNotThrow(() => new TradePriceAPI());
    }
    [Test()]
    public void TradePriceAPIMainTest()
    {
      Assert.DoesNotThrow(() => new TradePriceAPI(Environment.Main));
    }
    [Test()]
    public void TradePriceAPITestTest()
    {
      Assert.DoesNotThrow(() => new TradePriceAPI(Environment.Test));
    }
    [Test()]
    public void TradePriceAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new TradePriceAPI(mockRestService.Object));
    }
    [Test()]
    public void GetTradePriceTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<TradePrice>();
      mockRestService.Setup(x => x.Get<TradePrice>(It.IsAny<string>())).Returns(Task.FromResult(item));
      var service = new TradePriceAPI(mockRestService.Object);
      var result = service.GetTradePrice(Resources.bauxite).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<TradePrice>(It.Is<string>(y => y == "/tradeprice/resource=bauxite")));
    }
    [Test()]
    [Category("Integration")]
    public void GetTradePriceIntegrationTest()
    {
      var sut = new TradePriceAPI();
      var result = sut.GetTradePrice(Resources.steel).Result;
      Assert.IsNotNull(result);
    }
  }
}