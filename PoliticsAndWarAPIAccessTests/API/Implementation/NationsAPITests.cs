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
      var result = service.GetNations("test").Result;
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
      var result = service.GetNations("test",vm: true).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<NationsResponse>(It.Is<string>(y => y == "/nations/"), 
          It.Is<Dictionary<string,string>>(
            dict=> dict.Any(z => z.Key == "vm" && z.Value == "true"))
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
      var result = service.GetNations("test",allianceId: 148).Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<NationsResponse>(It.Is<string>(y => y == "/nations/"),
          It.Is<Dictionary<string, string>>(
            dict => dict.Any(z=> z.Key == "alliance_id" && z.Value == "148"))
        )
      );
    }
  }
}