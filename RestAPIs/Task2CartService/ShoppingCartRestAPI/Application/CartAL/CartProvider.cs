using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CartAL
{
    public class CartProvider : ICartProvider
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CartProvider(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public bool AddItem(CartItemDTO item)
        {
            throw new NotImplementedException();
        }

        public CartDTO GetCart(string cartId)
        {
            var cart = _repositoryManager.CartRepository.GetCart(cartId);
            if (cart != null)
            {
                return _mapper.Map<Cart, CartDTO>(cart);
            }
            return null;
        }

        public List<CartItemDTO> GetCartItems(string cartId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string cartId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
