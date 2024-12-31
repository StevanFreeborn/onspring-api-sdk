namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents the options for a request to retrieve all pages of fields for an app.
    /// </summary>
    public class GetAllFieldsPagesByAppRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the page size to retrieve. The default is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}