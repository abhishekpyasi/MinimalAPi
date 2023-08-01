namespace MinimalApiCQRS.Abstractions
{
    public interface IEndpointDefinition
    {

        public void RegisterEndpoints(WebApplication app);
    }
}
