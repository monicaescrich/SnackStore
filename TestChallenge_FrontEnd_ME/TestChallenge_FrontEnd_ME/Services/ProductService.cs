﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestChallenge_FrontEnd_ME.Domains.Services;
using TestChallenge_FrontEnd_ME.Models;

namespace TestChallenge_FrontEnd_ME.Services
{
    public class ProductService:IProduct
    {
        string _url= "http://localhost:57289/api/";
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> productList;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_url+"ListAllProducts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(apiResponse);
                }
            }
            return productList;
        }

        public async Task<int> GetCount() {
            var data = await GetAllProducts();
            return data.Count();
        }

        public async Task<IEnumerable<Product>> GetPaginatedResult(int currentPage, int pageSize = 9)
        {
            IEnumerable<Product> productList;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_url+"products?limit="+pageSize+"&offset="+currentPage*pageSize))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(apiResponse);
                }
            }
            return productList;
        }

       public async Task<IEnumerable<Product>> ListProductsByName(int currentPage, string name, int pageSize = 9)
        {
            IEnumerable<Product> productList;

            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync(_url+"GetProductByName?limit=" + pageSize + "&offset=" + currentPage * pageSize + "&name=" + name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(apiResponse);
                }
            }
            return productList;
        }

    }
}
