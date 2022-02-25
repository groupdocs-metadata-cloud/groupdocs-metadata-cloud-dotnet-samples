using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.InfoOperations
{
    /// <summary>
    /// This example demonstrates how to obtain document file information.
    /// </summary>
    public class GetDocumentInformation
    {
        public static void Run()
        {
            Console.WriteLine("Running GetDocumentInformation");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new InfoApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new InfoOptions()
                {
                    FileInfo = fileInfo
                };

                var request = new GetInfoRequest(options);

                var response = apiInstance.GetInfo(request);
                Console.WriteLine("InfoResult.PageCount: " + response.PageCount);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling InfoApi: " + e.Message + "\n");
            }
        }
    }
}