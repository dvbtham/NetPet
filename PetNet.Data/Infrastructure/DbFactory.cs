namespace PetNet.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PetNetDbContext dbContext;

        public PetNetDbContext Init()
        {
            return dbContext ?? (dbContext = new PetNetDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}