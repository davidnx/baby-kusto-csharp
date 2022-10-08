using System.Text.Json.Nodes;
using BabyKusto.Server.Contract;
using Microsoft.AspNetCore.Mvc;

namespace BabyKusto.SampleServer.Controllers
{
    [ApiController]
    public class MgmtController : ControllerBase
    {
        private readonly ILogger<MgmtController> _logger;

        public MgmtController(ILogger<MgmtController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/v1/rest/mgmt")]
        public IActionResult Execute(KustoApiMgmtRequestBody body)
        {
            if (body == null)
            {
                return this.BadRequest();
            }



            var result = new KustoApiResult();
            switch (body.Csl)
            {
                case ".show version":
                    result.Tables.Add(
                        new KustoApiTableResult
                        {
                            TableName = "Table_0",
                            Columns = {
                                new KustoApiColumnDescription { ColumnName = "BuildVersion", DataType = "String" },
                                new KustoApiColumnDescription { ColumnName = "BuildTime", DataType = "DateTime" },
                                new KustoApiColumnDescription { ColumnName = "ServiceType", DataType = "String" },
                                new KustoApiColumnDescription { ColumnName = "ProductVersion", DataType = "String" },
                                new KustoApiColumnDescription { ColumnName = "ServiceOffering", DataType = "String" },
                            },
                            Rows =
                            {
                                new JsonArray(JsonValue.Create("0.0.0"), JsonValue.Create("2022-10-07T23:00:00Z"), JsonValue.Create("Engine"), JsonValue.Create("0.0.0"), JsonValue.Create("{\"Type\":\"Azure Data Explorer\"}")),
                            },
                        });
                    break;
                case ".show databases":
                    result.Tables.Add(
                        new KustoApiTableResult
                        {
                            TableName = "Table_0",
                            Columns = {
                                new KustoApiColumnDescription { ColumnName = "DatabaseName", DataType = "String", ColumnType = "string" },
                                new KustoApiColumnDescription { ColumnName = "PersistentStorage", DataType = "String", ColumnType = "string" },
                                new KustoApiColumnDescription { ColumnName = "Version", DataType = "String", ColumnType = "string" },
                                new KustoApiColumnDescription { ColumnName = "IsCurrent", DataType = "Boolean", ColumnType = "bool" },
                                new KustoApiColumnDescription { ColumnName = "DatabaseAccessMode", DataType = "String", ColumnType = "string" },
                                new KustoApiColumnDescription { ColumnName = "PrettyName", DataType = "String", ColumnType = "string" },
                                new KustoApiColumnDescription { ColumnName = "ReservedSlot1", DataType = "Boolean", ColumnType = "bool" },
                                new KustoApiColumnDescription { ColumnName = "DatabaseId", DataType = "Guid", ColumnType = "guid" },
                                new KustoApiColumnDescription { ColumnName = "InTransitionTo", DataType = "String", ColumnType = "string" },
                            },
                            Rows =
                            {
                                new JsonArray(
                                    JsonValue.Create("BabyKustoDB"),
                                    JsonValue.Create(""),
                                    JsonValue.Create("v1.0"),
                                    JsonValue.Create(false),
                                    JsonValue.Create("ReadWrite"),
                                    JsonValue.Create<string>(null),
                                    JsonValue.Create<string>(null),
                                    JsonValue.Create("DAF72ECA-B812-4C98-BDA8-D4A9C28A9E9E"),
                                    JsonValue.Create("")
                                )
                            },
                        });
                    break;
                case ".show schema as json":
                case ".show databases  schema as json":
                case ".show databases (['BabyKustoDB']) schema as json":
                    result.Tables.Add(
                        new KustoApiTableResult
                        {
                            TableName = "Table_0",
                            Columns = {
                                new KustoApiColumnDescription { ColumnName = "ClusterSchema", DataType = "String", ColumnType = "string" },
                            },
                            Rows =
                            {
                                new JsonArray(JsonValue.Create("{\"Databases\": { \"BabyKustoDB\": { \"Name\": \"BabyKustoDB\" }}}")),
                            },
                        });
                    break;
                case ".show cluster monitoring":
                default:
                    return this.BadRequest($"Management csl command not supported: {body.Csl}");
            }

            return this.Ok(result);
        }
    }
}