using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetReportRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetReportRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetReportRequestBuilder(_client);
        }

        [TestMethod]
        public void FromReport_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var reportId = 1;

            var builder = _builder.FromReport(reportId);

            Assert.IsInstanceOfType<IGetReportDataRequestBuilder>(builder);
            Assert.AreEqual(reportId, builder.ReportId);
            Assert.AreEqual(DataFormat.Raw, builder.Format);
            Assert.AreEqual(ReportDataType.ReportData, builder.DataType);
        }
    }
}