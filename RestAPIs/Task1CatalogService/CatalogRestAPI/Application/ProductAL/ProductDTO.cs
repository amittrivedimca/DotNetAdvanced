﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductAL
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        
        public decimal Price { get; set; }
        public int Amount { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Product, ProductDTO>();
                CreateMap<ProductDTO,Product>();
            }
        }
    }
}