using PetNet.Data.Infrastructure;
using PetNet.Data.Repositories;
using PetNet.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PetNet.Service
{
    public interface IReviewService
    {
        Review Add(Review entity);

        void Update(Review entity);

        void Delete(int id);

        Review FindById(int id);

        bool CanReview(long pid, string uid);

        void SaveChanges();

        IEnumerable<Review> GetInProductDetail(long pid, int page, int pageSize, out int totalRow, bool include = false);

        IEnumerable<Review> GetAll(int page, int pageSize, out int totalRow, bool include = false);
    }

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            this.orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public Review Add(Review entity)
        {
            return _reviewRepository.Add(entity);
        }

        public bool CanReview(long pid, string uid)
        {
            var reviews = _reviewRepository.GetMulti(x => !x.IsDeleted && x.ProductId == pid && x.CustomerId == uid);

            var userOrders = orderRepository.GetMulti(x => x.CustomerId == uid && !x.IsCancel).Include(x => x.OrderDetails);

            var orderDetail = userOrders.Select(x => x.OrderDetails.Any(c => c.ProductID == pid));

            return reviews.Count() <= 0 && orderDetail.Any(x => x == true);
        }

        public void Delete(int id)
        {
            try
            {
                var review = FindById(id);
                review.IsDeleted = true;
            }
            catch (System.Exception)
            {

            }
        }

        public Review FindById(int id)
        {
            return _reviewRepository.GetSingleById(id);
        }

        public IEnumerable<Review> GetAll(int page, int pageSize, out int totalRow, bool include = false)
        {
            var query = new List<Review>();

            if (include)
            {
                query = _reviewRepository.GetMulti(x => !x.IsDeleted, new[] { "Customer" }).ToList();
                totalRow = query.Count();
                return query.Skip((page - 1) * pageSize).Take(pageSize);
            }

            query = _reviewRepository.GetMulti(x => !x.IsDeleted).ToList();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Review> GetInProductDetail(long pid, int page, int pageSize, out int totalRow, bool include = false)
        {
            var query = new List<Review>();

            if (include)
            {
                query = _reviewRepository.GetMulti(x => x.ProductId == pid && !x.IsDeleted, new[] { "Customer" }).ToList();
                totalRow = query.Count();
                return query.Skip((page - 1) * pageSize).Take(pageSize);
            }

            query = _reviewRepository.GetMulti(x => x.ProductId == pid && !x.IsDeleted).ToList();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Review entity)
        {
            _reviewRepository.Update(entity);
        }
    }
}
