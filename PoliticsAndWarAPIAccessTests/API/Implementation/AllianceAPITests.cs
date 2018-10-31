using AutoFixture;
using Moq;
using NUnit.Framework;
using PoliticsAndWarAPIAccess.API.Implementation;
using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation.Tests
{
  [TestFixture()]
  public class AllianceAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void AllianceAPITest()
    {
      Assert.DoesNotThrow(() => new AllianceAPI());
    }
    [Test()]
    public void AllianceAPIMainTest()
    {
      Assert.DoesNotThrow(() => new AllianceAPI(Environment.Main));
    }
    [Test()]
    public void AllianceAPITestTest()
    {
      Assert.DoesNotThrow(() => new AllianceAPI(Environment.Test));
    }
    [Test()]
    public void AllianceAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new AllianceAPI(mockRestService.Object));
    }
    [Test()]
    public void GetAllianceTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<Alliance>();
      mockRestService.Setup(x => x.Get<Alliance>(It.IsAny<string>())).Returns(Task.FromResult(item));
      var service = new AllianceAPI(mockRestService.Object);
      var result = service.GetAlliance(1).Result;
      Assert.AreEqual(item,result);
      mockRestService.Verify(x => x.Get<Alliance>(It.Is<string>(y => y == "/alliance/id=1")));
    }
    [Test()]
    [Category("Integration")]
    public void GetAllianceIntegrationTest()
    {
      var alliances = new AllianceAPI();
      var result = alliances.GetAlliance(4124).Result;
      Assert.IsNotNull(result);
    }
  }
}