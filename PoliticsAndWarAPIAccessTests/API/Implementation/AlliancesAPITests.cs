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
  public class AlliancesAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void AlliancesAPITest()
    {
      Assert.DoesNotThrow(() => new AlliancesAPI());
    }
    [Test()]
    public void AlliancesAPIMainTest()
    {
      Assert.DoesNotThrow(() => new AlliancesAPI(Environment.Main));
    }
    [Test()]
    public void AlliancesAPITestTest()
    {
      Assert.DoesNotThrow(() => new AlliancesAPI(Environment.Test));
    }
    [Test()]
    public void AlliancesAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new AlliancesAPI(mockRestService.Object));
    }
    [Test()]
    public void GetAlliancesTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<AlliancesResponse>();
      mockRestService.Setup(x => x.Get<AlliancesResponse>(It.IsAny<string>(),null)).Returns(Task.FromResult(item));
      var service = new AlliancesAPI(mockRestService.Object);
      var result = service.GetAlliances().Result;
      Assert.AreEqual(item,result);
      mockRestService.Verify(x => x.Get<AlliancesResponse>(It.Is<string>(y => y == "/alliances/"), null));
    }
    [Test()]
    [Category("Integration")]
    public void GetAlliancesIntegrationTest()
    {
      var alliances = new AlliancesAPI();
      var result = alliances.GetAlliances().Result;
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result.alliances);
    }
  }
}