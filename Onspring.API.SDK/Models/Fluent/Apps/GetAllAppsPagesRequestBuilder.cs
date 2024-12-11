using Onspring.API.SDK.Interfaces.Fluent;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetAllAppsPagesRequestBuilder : IGetAllAppsPagesRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int PageSize { get; private set; } = 50;

        internal GetAllAppsPagesRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetAllAppsPagesRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public async IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>> SendAsync()
        {
            await foreach (var response in _client.GetAllAppsAsync(PageSize))
            {
                yield return response;
            }
        }
    }
}