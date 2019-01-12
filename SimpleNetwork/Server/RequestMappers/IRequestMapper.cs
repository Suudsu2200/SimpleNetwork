using SimpleNetwork.Requests;

namespace SimpleNetwork.Server.RequestMappers
{
    public interface IRequestMapper
    {
        HandlerMethodWrapper MapRequest(object request);
    }
}
