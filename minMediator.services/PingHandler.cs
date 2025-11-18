using minMediator.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minMediator.services
{

    internal class PingHandler : IRequestHandler<PingRequest, Result<string>>
    {
        public async Task<Result<string>> Handle(PingRequest request)
        {
            await Task.Delay(10);
            if (Random.Shared.Next(2) % 2 == 0 )
                return Result<string>.Success($"{DateTimeOffset.Now} Pong");

            return Result<string>.Failure(new Exception("Failed"));
        }
    }
}
