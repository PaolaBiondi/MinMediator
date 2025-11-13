using minMediator.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minMediator.services
{

    internal class PingHandler : IRequestHandler<PingRequest, string>
    {
        public async Task<string> Handle(PingRequest request)
        {
            await Task.Delay(10);
            return $"{DateTimeOffset.Now} Pong";
        }
    }
}
