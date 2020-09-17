using AislesAPI.Controllers;
using AislesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AislesApi.Tests
{
    class AisleIdentifiersUnitTests
    {

        [Test]
        public void GetAllAisles_ReturnsAllRecords()
        {
            //This test is the basic layout if you want to simulate database queries using linq.
            //Arrange
            var Aisles = new List<Aisle>
            {
                new Aisle()
                {
                    AisleID = 1,
                    AisleName = "Fruits",
                    Sections = new List<Section>
                    {
                        new Section()
                        {
                            SectionID = 1,
                            SectionName = "Apples",
                            AisleID = 1
                        },
                        new Section()
                        {
                            SectionID = 2,
                            SectionName = "Oranges",
                            AisleID = 1
                        },
                        new Section()
                        {
                            SectionID = 3,
                            SectionName = "Bananas",
                            AisleID = 1
                        }
                    }
                    
                    
                },
                new Aisle()
                {
                    AisleID = 2,
                    AisleName = "Vegetables",
                    Sections = new List<Section>
                    {
                        new Section()
                        {
                            SectionID = 4,
                            SectionName = "Carrot",
                            AisleID = 2
                        },
                        new Section()
                        {
                            SectionID = 5,
                            SectionName = "Lettuce",
                            AisleID = 2
                        }
                    }
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Aisle>>();
            mockSet.As<IQueryable<Aisle>>().Setup(m => m.Provider).Returns(Aisles.Provider);
            mockSet.As<IQueryable<Aisle>>().Setup(m => m.Expression).Returns(Aisles.Expression);
            mockSet.As<IQueryable<Aisle>>().Setup(m => m.ElementType).Returns(Aisles.ElementType);
            mockSet.As<IQueryable<Aisle>>().Setup(m => m.GetEnumerator()).Returns(Aisles.GetEnumerator());

            var mockContext = new Mock<AppDatabase>();
            mockContext.Setup(c => c.Aisles).Returns(mockSet.Object);
            //Act
            var service = new AislesController(mockContext.Object);
            var results = service.GetAisles().ToList();

            //Assert
           // Assert.AreEqual(2, results.Count());
            //Assert.AreEqual(Aisles, results);
            Assert.AreEqual("Vegetables", results[1].AisleID);

        }


    }
}
