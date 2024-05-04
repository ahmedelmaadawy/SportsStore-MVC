using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore_MVC.Controllers;
using SportsStore_MVC.Models;
using SportsStore_MVC.Models.ViewModels;
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
            ProductListViewModel result =
                (controller.Index(null) as ViewResult)?.ViewData.Model as ProductListViewModel ?? new();

            //Assert
            Product[] ProdArray = result.Products.ToArray();
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
            ProductListViewModel result =
                controller.Index(null, 2)?.ViewData.Model as ProductListViewModel ?? new();

            //Assert
            Product[] productArray = result.Products.ToArray();
            Assert.True(productArray.Length == 2);
            Assert.Equal("P4", productArray[0].Name);
            Assert.Equal("P5", productArray[1].Name);
        }
        [Fact]
        public void Can_Send_Pagination_View_Model()
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
            HomeController controller = new HomeController(mock.Object) { PageSize = 3 };
            //Act
            ProductListViewModel result =
                controller.Index(null, 2)?.ViewData.Model as ProductListViewModel ?? new();

            //Assert
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.Equal(2, pagingInfo.CurrentPage);
            Assert.Equal(3, pagingInfo.ItemsPerPage);
            Assert.Equal(5, pagingInfo.TotalItems);
            Assert.Equal(2, pagingInfo.TotalPage);
        }

        [Fact]
        public void Can_Filter_Products()
        {

            //Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name ="P1",Category="Cat1"},
                new Product {ProductId = 2, Name ="P2",Category="Cat2"},
                new Product {ProductId = 3, Name ="P3",Category="Cat3"},
                new Product {ProductId = 4, Name ="P4",Category="Cat2"},
                new Product {ProductId = 5, Name ="P5",Category="Cat5"},

            }).AsQueryable<Product>);

            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;
            //Act
            Product[] result =
                (controller.Index("Cat2", 2)?.ViewData.Model as ProductListViewModel ?? new()).Products.ToArray();
            //Assert
            Assert.Equal(2,result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
        }
    }
}
