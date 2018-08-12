namespace PetNet.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}