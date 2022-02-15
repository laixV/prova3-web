using System;
using Super_Market.Domain.Models;

namespace Super_Market.Domain.Services.Communication
{
    public class ProductResponse: BaseResponse
    {
        public Product Product { get; private set;}
        
        public ProductResponse(bool sucess, string message, Product product) : base(sucess, message)
        {
            Product = product;
        }

        public ProductResponse(Product product) : this(true, String.Empty, product)
        {
            
        }

        public ProductResponse(string message) : this(false, message, null)
        {
            
        }
        
    }
}