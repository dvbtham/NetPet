using AutoMapper;
using MvcPaging;
using System.Collections.Generic;
using System.Web.Mvc;
using PetNet.Model.Models;
using PetNet.Service;
using PetNet.Web.Models;

namespace PetNet.Web.Controllers
{
    public class CommonController : Controller
    {
        private IProductService _productService;

        public CommonController(IProductService productService)
        {
            _productService = productService;
        }
        
        public IList<ProductViewModel> ProductListAjax(int? page, string searchString)
        {
            IList<Product> listProducts = _productService.GetAllPagingAjax(searchString);

            var listProductsVm = Mapper.Map<IList<Product>, IList<ProductViewModel>>(listProducts);
            return listProductsVm;
        }
    }
}