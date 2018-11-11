using SimpleNetwork.Requests;

namespace SimpleNetwork.Server.RequestMappers
{
    public interface IRequestMapper
    {
        HandlerMethodWrapper MapRequest(IRequest request);
    }
}
