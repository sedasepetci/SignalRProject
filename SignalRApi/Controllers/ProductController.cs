﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
      

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
               ProductName= createProductDto.ProductName,
               ImageUrl= createProductDto.ImageUrl,
               Price= createProductDto.Price,
               ProductStatus= createProductDto.ProductStatus,
            });
            return Ok("Ürün Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value=_productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi.");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
       var value=_productService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
         public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                Description= updateProductDto.Description,
                ProductName= updateProductDto.ProductName,
                ImageUrl= updateProductDto.ImageUrl,
                Price= updateProductDto.Price,
                ProductStatus= updateProductDto.ProductStatus,

            });
            return Ok("Ürün bilgisi güncellendi");
        }
    }
}
