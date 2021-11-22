using FlashParkMVP.DataModels;
using FlashParkMVP.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
//using System.Threading.Tasks;

namespace FlashParkMVPTest
{
    [TestClass]
    public class ParkingLotServiceTest
    {

        [TestMethod]
        public void random()
        {
            Assert.AreEqual(3, 3);
        }

        [TestMethod]
        public async Task GetParkingLotsAsyncTestCheckCount()
        {

            var data = new List<ParkingLot>()
            {
                new ParkingLot() { ParkingLotId = 2, ParkingLotAddress = "Garage1" },
                new ParkingLot() { ParkingLotId = 3, ParkingLotAddress = "Garage2" },
                new ParkingLot() { ParkingLotId = 1, ParkingLotAddress = "Garage3" }
            }.AsQueryable();

            //var mockSet = new Mock<DbSet<ParkingLot>>();
            //mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //var mockContext = new Mock<DBContext>();
            //mockContext.Setup(c => c.ParkingLots).Returns(mockSet.Object);

            //var service = new ParkingLotService(mockContext.Object);
            //var lots = service.GetParkingLotsAsync().Result; 


            //var mockSet = new Mock<System.Data.Entity.DbSet<ParkingLot>>();
            var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<ParkingLot>>();
            mockSet.As<IDbAsyncEnumerable<ParkingLot>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<ParkingLot>(data.GetEnumerator()));

            mockSet.As<IQueryable<ParkingLot>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<ParkingLot>(data.Provider));

            mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ParkingLot>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DBContext>();
            mockContext.Setup(c => c.ParkingLots).Returns(mockSet.Object);

            var service = new ParkingLotService(mockContext.Object);
            var lots = await service.GetParkingLotsAsync();

            Assert.AreEqual(3, lots.ToList().Count);

            Assert.AreEqual(3, 3);

        }
    }
}
