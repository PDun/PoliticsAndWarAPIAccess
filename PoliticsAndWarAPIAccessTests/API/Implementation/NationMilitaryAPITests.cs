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
  public class NationMilitaryAPITests
  {
    Mock<IRestService> mockRestService;
    [SetUp]
    public void SetUp()
    {
      mockRestService = new Mock<IRestService>();
    }
    [Test()]
    public void NationMilitaryAPITest()
    {
    }

    [Test()]
    public void NationMilitaryAPITest1()
    {
    }

    [Test()]
    public async Task GetNationMilitaryTest()
    {
      Fixture fixture = new Fixture();
      var item = fixture.Create<NationMilitaryResponse>();
      mockRestService.Setup(x => x.Get<NationMilitaryResponse>(It.IsAny<string>(), null)).Returns(Task.FromResult(item));

      var service = new NationMilitaryAPI(mockRestService.Object);
      var result = (await service.GetNationMilitary("key"));
      Assert.AreEqual(item, result);
      mockRestService.Verify(x => x.Get<NationMilitaryResponse>(It.Is<string>(y => y == "/nation-military/key=key"), null));
    }
  }
}