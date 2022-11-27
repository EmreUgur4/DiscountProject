using DiscountProject.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiscountProject.Test
{
    public class DiscountTest
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;

        public DiscountTest()
        {
            _factory = new WebApplicationFactory<Program>();
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAPITest1()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-1");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest2()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-2");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest3()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-3");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest4()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-4");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest5()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-5");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest6()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-6");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest7()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-7");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAPITest8()
        {
            var okResult = await _httpClient.GetAsync("http://localhost:5045/api/Invoices/GetDiscount?invoiceNo=Inv-8");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}
