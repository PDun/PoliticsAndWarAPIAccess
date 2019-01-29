using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class NationsAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void NationsAPITest()
    {
      Assert.DoesNotThrow(() => new NationsAPI());
    }
    [Test()]
    public void NationsAPIMainTest()
    {
      Assert.DoesNotThrow(() => new NationsAPI(Environment.Main));
    }
    [Test()]
    public void NationsAPITestTest()
    {
      Assert.DoesNotThrow(() => new NationsAPI(Environment.Test));
    }
    [Test()]
    public void NationsAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new NationsAPI(mockRestService.Object));
    }
    [Test()]
    public void GetNationsTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<NationsResponse>();
      mockRestService.Setup(x => x.Get<NationsResponse>(It.IsAny<string>(), It.IsAny<Dictionary<string,string>>())).Returns(Task.FromResult(item));
      var service = new NationsAPI(mockRestService.Object);
      var result = service.GetNations().Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<NationsResponse>(It.Is<string>(y => y == "/nations/"), It.IsAny<Dictionary<string, string>>()));
    }
    [Test()]
    public void GetNationsVmTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<NationsResponse>();
      mockRestService.Setup(x => x.Get<NationsResponse>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(Task.FromResult(item));
      var service = new NationsAPI(mockRestService.Object);
      var result = service.GetNations(vm: true).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<NationsResponse>(It.Is<string>(y => y == "/nations/"), 
          It.Is<Dictionary<string,string>>(
            dict=> dict.First().Key == "vm" && dict.First().Value == "true")
        )
      );
    }
    [Test()]
    public void GetNationsAllianceTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<NationsResponse>();
      mockRestService.Setup(x => x.Get<NationsResponse>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(Task.FromResult(item));
      var service = new NationsAPI(mockRestService.Object);
      var result = service.GetNations(allianceId: 148).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<NationsResponse>(It.Is<string>(y => y == "/nations/"),
          It.Is<Dictionary<string, string>>(
            dict => dict.First().Key == "vm" && dict.First().Value == "true")
        )
      );
    }
    [Test()]
    [Category("Integration")]
    public void GetNationsIntegrationTest()
    {
      var sut = new NationsAPI();
      var result = sut.GetNations().Result;
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result.nations);
    }
    [Test()]
    [Category("Integration")]
    public void GetNationsIntegrationVmsTest()
    {
      var sut = new NationsAPI();
      var result = sut.GetNations(vm: true).Result;
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result.nations);
      Assert.IsTrue(result.nations.Any(x => x.vacmode == "1"));
    }
    [Test()]
    [Category("Integration")]
    public void GetNationsIntegrationminScoreTest()
    {
      var sut = new NationsAPI();
      var result = sut.GetNations(min_score: 1000).Result;
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result.nations);
      Assert.IsTrue(result.nations.All(x => x.score >= 1000));
    }
    [Test()]
    [Category("Integration")]
    public void GetNationsIntegrationMaxScoreTest()
    {
      var sut = new NationsAPI();
      var result = sut.GetNations(max_score: 1000).Result;
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result.nations);
      Assert.IsTrue(result.nations.All(x => x.score <= 1000));
    }
    [Test()]
    [Category("Integration")]
    public void GetNationsIntegrationAllianceScoreTest()
    {
      var sut = new NationsAPI();
      var result = sut.GetNations(allianceId: 0).Result;
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result.nations);
      Assert.IsTrue(result.nations.All(x => x.allianceid == 0));
    }
  }
}