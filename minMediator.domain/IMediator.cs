using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minMediator.domain
{
    public interface IMediator
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest request);
    }
}
