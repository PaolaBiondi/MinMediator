using minMediator.domain;

namespace minMediator.api
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TRequest, TResponse>(TRequest request)
        {
            var handler = _serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();
            
            if (handler == null)
            {
                throw new InvalidOperationException($"No handler found for request type {typeof(TRequest).FullName}");
            }
            
            return await handler.Handle(request);
        }
    }
}
