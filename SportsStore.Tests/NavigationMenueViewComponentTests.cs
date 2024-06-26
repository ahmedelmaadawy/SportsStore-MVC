﻿using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore_MVC.Components;
using SportsStore_MVC.Models;
using SportsStore_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SportsStore.Tests
{
    public class NavigationMenueViewComponentTests
    {
        [Fact]
        public void Can_select_Categories()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId =1, Name ="P1",Category ="Apples"},

                new Product {ProductId =2, Name ="P2",Category ="Apples"},

                new Product {ProductId =3, Name ="P3",Category ="Plums"},

                new Product {ProductId =4, Name ="P4",Category ="Oranges"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            //Act 
            string[] results = ((IEnumerable<string>?)(target.Invoke() as ViewViewComponentResult)?.ViewData?.Model
                ?? Enumerable.Empty<string>()).ToArray();

            //Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples",  "Oranges", "Plums" },results));
                

        }
    }
}
