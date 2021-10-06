using System;
using Xunit;
using FluentAssertions;
using lib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using web;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace test
{
    public class HouseHuntControllerTest
    {

        private HouseHuntController _controller;
        private Mock<IPropertyRepository> _mockRepository;
        private DefaultHttpContext _httpContext;
        public HouseHuntControllerTest()
        {
            _mockRepository = new Mock<IPropertyRepository>();
            _httpContext = new DefaultHttpContext();
            _controller = new HouseHuntController(_mockRepository.Object)
            { ControllerContext = new ControllerContext() { HttpContext = _httpContext } };
        }



    }
}