using System;

namespace PetNet.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PetNetDbContext Init();
    }
}