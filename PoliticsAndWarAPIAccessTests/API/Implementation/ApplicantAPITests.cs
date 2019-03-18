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
  public class ApplicantAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void ApplicantAPITest()
    {
      Assert.DoesNotThrow(() => new ApplicantAPI());
    }
    [Test()]
    public void ApplicantAPIMainTest()
    {
      Assert.DoesNotThrow(() => new ApplicantAPI(Environment.Main));
    }
    [Test()]
    public void ApplicantAPITestTest()
    {
      Assert.DoesNotThrow(() => new ApplicantAPI(Environment.Test));
    }
    [Test()]
    public void ApplicantAPIServiceTest()
    {
      Assert.DoesNotThrow(() => new ApplicantAPI(mockRestService.Object));
    }
    [Test()]
    public void GetApplicantTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<ApplicantResponse>();
      mockRestService.Setup(x => x.Get<ApplicantResponse>(It.IsAny<string>(), null)).Returns(Task.FromResult(item));
      var service = new ApplicantAPI(mockRestService.Object);
      var result = service.GetApplicant(4124, "test").Result;
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<ApplicantResponse>(It.Is<string>(y => y == "/applicants/4124/?key=test"), null));
    }
    [Test()]
    [Category("Integration")]
    public void GetApplicantIntegrationTest()
    {
      var sut = new ApplicantAPI();
      var result = sut.GetApplicant(4124, "test").Result;
      if (result.success)
      {
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result.nations);
      }
    }
  }
}