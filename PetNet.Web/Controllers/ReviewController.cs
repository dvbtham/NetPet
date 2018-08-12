using Microsoft.AspNet.Identity;
using PetNet.Common;
using PetNet.Model.Models;
using PetNet.Service;
using PetNet.Web.Infrastructure.Core;
using PetNet.Web.Models;
using System;
using System.Web.Mvc;

namespace PetNet.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public ActionResult Index(long pid, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));

            int totalRow = 0;

            var reviews = reviewService.GetInProductDetail(pid, page, pageSize, out totalRow, include: true);

            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<Review>()
            {
                Items = reviews,
                MaxPage = int.Parse(ConfigHelper.GetByKey("maxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View("_ReviewList", paginationSet);
        }

        [HttpPost]
        public ActionResult Create(ReviewViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        status = false,
                        msg = "Dữ liệu đầu vào không hợp lệ! Kiểm tra lại."
                    });
                }

                var userId = User.Identity.GetUserId();

                var review = new Review
                {
                    CustomerId = userId,
                    ProductId = viewModel.ProductId,
                    Content = viewModel.Content,
                    Rating = viewModel.Rating
                };

                reviewService.Add(review);
                reviewService.SaveChanges();

                return Json(new
                {
                    status = true,
                    msg = "Đánh giá thành công."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    msg = ex.Message
                });
            }
        }
    }
}