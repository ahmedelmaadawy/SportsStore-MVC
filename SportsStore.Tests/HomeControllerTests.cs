using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore_MVC.Controllers;
using SportsStore_MVC.Models;
using SportsStore_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            //Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name ="P1"},
                new Product {ProductId = 2, Name ="P2"},
            }).AsQueryable<Product>);
            HomeController controller = new HomeController(mock.Object);
            //Act
            IEnumerable<Product> ?result = 
                (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Product[] ProdArray = result?.ToArray() ?? Array.Empty<Product>();
            Assert.True(ProdArray.Length == 2);
            Assert.Equal("P1", ProdArray[0].Name);
            Assert.Equal("P2", ProdArray[1].Name);
        }
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name ="P1"},
                new Product {ProductId = 2, Name ="P2"},
                new Product {ProductId = 3, Name ="P3"},
                new Product {ProductId = 4, Name ="P4"},
                new Product {ProductId = 5, Name ="P5"},

            }).AsQueryable<Product>);
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            //Act
            IEnumerable<Product> result = (controller.Index(2) as ViewResult)?
                .ViewData.Model as IEnumerable<Product>?? Enumerable.Empty<Product>();
            //Assert
            Product[] productArray = result.ToArray();
            Assert.True(productArray.Length == 3);
            Assert.Equal("P4", productArray[0].Name);
            Assert.Equal("P5", productArray[1].Name);
         }
    }
}
