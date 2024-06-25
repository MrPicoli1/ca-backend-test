using BackendTest.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BackendTest.Test
{
    public class ApiFactory : WebApplicationFactory<IApiAssemblyMarker>
    {
    }
}
