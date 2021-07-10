using System;

namespace ecommerce_skinet_shop.Infrustructure
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
