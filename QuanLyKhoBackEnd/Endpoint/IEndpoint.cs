namespace QuanLyKhoBackEnd.Endpoint
{
    public interface IEndpoint
    {
        static abstract void MapEndpoint(IEndpointRouteBuilder app);
    }
}
