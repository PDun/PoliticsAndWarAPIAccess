using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class TradeHistoryAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void TradeHistoryAPITest()
    {
      Assert.DoesNotThrow(() => new TradeHistoryAPI());
    }
    [Test()]
    public void TradeHistoryAPIMainTest()
    {
      Assert.DoesNotThrow(() => new TradeHistoryAPI(Environment.Main));
    }
    [Test()]
    public void TradeHistoryAPITestTest()
    {
      Assert.DoesNotThrow(() => new TradeHistoryAPI(Environment.Test));
    }
    [Test()]
    public void TradeHistoryAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new TradeHistoryAPI(mockRestService.Object));
    }
    [Test()]
    public void GetTradeHistoryTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<TradeHistoryResponse>();
      mockRestService.Setup(x => x.Get<TradeHistoryResponse>(It.IsAny<string>())).Returns(Task.FromResult(item));
      var service = new TradeHistoryAPI(mockRestService.Object);
      var result = service.GetTradeHistory("test",new Resources[] { Resources.steel}).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<TradeHistoryResponse>(It.Is<string>(y => y == "/trade-history/key=test&resources=steel&records=10000")));
    }

    [Test()]
    public void GetTradeHistoryMultipleResourcesTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<TradeHistoryResponse>();
      mockRestService.Setup(x => x.Get<TradeHistoryResponse>(It.IsAny<string>())).Returns(Task.FromResult(item));
      var service = new TradeHistoryAPI(mockRestService.Object);
      var result = service.GetTradeHistory("test", new Resources[] { Resources.steel, Resources.oil }).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<TradeHistoryResponse>(It.Is<string>(y => y == "/trade-history/key=test&resources=steel,oil&records=10000")));
    }

    [Test()]
    public void GetTradeHistoryMultipleResourceslimitTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<TradeHistoryResponse>();
      mockRestService.Setup(x => x.Get<TradeHistoryResponse>(It.IsAny<string>())).Returns(Task.FromResult(item));
      var service = new TradeHistoryAPI(mockRestService.Object);
      var result = service.GetTradeHistory("test", new Resources[] { Resources.steel, Resources.oil },500).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<TradeHistoryResponse>(It.Is<string>(y => y == "/trade-history/key=test&resources=steel,oil&records=500")));
    }
  }
}