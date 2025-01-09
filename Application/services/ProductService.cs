using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Modules.Products.Commands;
using Application.Modules.Products.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<string> CreateProduct(AddProduct addProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(addProductDto);
            var productId = await _mediator.Send(command);
            return productId;
        }

        public async Task<ReadProduct> GetProductById(GetProductByIdQuery query)
        {
            var product = await _mediator.Send(query);
            return product;
        }

 
    }
}
