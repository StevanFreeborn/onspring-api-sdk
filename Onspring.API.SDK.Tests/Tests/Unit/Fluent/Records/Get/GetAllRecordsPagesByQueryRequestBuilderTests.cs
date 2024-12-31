using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAllRecordsPagesByQueryRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static IOnspringClient _client;
        private static GetAllRecordsPagesByQueryRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstance()
        {
            var builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByQueryRequestBuilder>(builder);
            Assert.AreEqual(_appId, builder.AppId);
            Assert.AreEqual(50, builder.PageSize);
            Assert.AreEqual(DataFormat.Raw, builder.DataFormat);
            Assert.AreEqual(0, builder.FieldIds.Count());
        }

        [TestMethod]
        public void WithDataFormat_WhenCalled_ItShouldReturnAnInstance()
        {
            var dataFormat = DataFormat.Formatted;
            var builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );

            builder.WithDataFormat(dataFormat);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByQueryRequestBuilder>(builder);
            Assert.AreEqual(dataFormat, builder.DataFormat);
        }

        [TestMethod]
        public void WithFields_WhenCalled_ItShouldReturnAnInstance()
        {
            var fieldIds = new[] { 1, 2, 3 };
            var builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );

            builder.WithFields(fieldIds);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByQueryRequestBuilder>(builder);
            Assert.AreEqual(fieldIds, builder.FieldIds);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldReturnAnInstance()
        {
            var pageSize = 100;
            var builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );

            builder.WithPageSize(pageSize);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByQueryRequestBuilder>(builder);
            Assert.AreEqual(pageSize, builder.PageSize);
        }

        [TestMethod]
        public void WithFilter_WhenCalledWithFilterString_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var filter = "filter";
            var builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );

            builder.WithFilter(filter);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByQueryRequestBuilder>(builder);
            Assert.AreEqual(filter, builder.Filter);
        }

        [TestMethod]
        public void WithFilter_WhenCalledWithFilterAction_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var filter = new Filter(1, FilterOperator.Equal, "value");
            var builder = new GetAllRecordsPagesByQueryRequestBuilder(
                _client,
                _appId,
                50,
                [],
                DataFormat.Raw,
                null
            );

            builder.WithFilter(f =>
            {
                f.FieldId = filter.FieldId;
                f.Operator = filter.Operator;
                f.Value = filter.Value;
            });

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByQueryRequestBuilder>(builder);
            Assert.AreEqual(filter.ToString(), builder.Filter);
        }

        [TestMethod]
        public void SendAsync_WhenCalled_ItShouldReturnAnAsyncEnumerable()
        {
            var result = _builder.SendAsync();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>>>(result);
        }

        [TestMethod]
        public void SendAsync_WhenCalledWithOptions_ItShouldReturnAnAsyncEnumerable()
        {
            var result = _builder
                .WithFilter("filter")
                .SendAsync(o =>
                {
                    o.PageSize = 100;
                    o.FieldIds = [1, 2, 3];
                    o.DataFormat = DataFormat.Formatted;
                });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetPagedRecordsResponse>>>(result);
        }
    }
}