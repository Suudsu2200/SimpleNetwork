namespace SimpleNetwork.Server.RequestHandlers
{
    public interface IRequestHandler
    {
        void Handle(object request);
    }
}
