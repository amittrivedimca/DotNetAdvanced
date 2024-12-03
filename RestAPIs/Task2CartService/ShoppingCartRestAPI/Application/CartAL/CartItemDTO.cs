﻿using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartAL
{
    public class CartItemDTO
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public ItemImageInfoDTO ItemImage { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CartItem, CartItemDTO>();
                CreateMap<CartItemDTO, CartItem>();
            }
        }
    }
}