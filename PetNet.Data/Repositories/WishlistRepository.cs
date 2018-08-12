using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {

    }
    public class WishlistRepository : RepositoryBase<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
