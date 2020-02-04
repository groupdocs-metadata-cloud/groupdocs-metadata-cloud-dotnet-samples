using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.InfoOperations
{
    /// <summary>
    /// This example demonstrates how to obtain metadata tags.
    /// </summary>
    public class GetMetadataTagsInformation
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new InfoApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new TagsOptions
                {
                    FileInfo = fileInfo
                };

                var request = new TagsRequest(options);

                // Get tags
                var response = apiInstance.Tags(request);
                Console.WriteLine($"Root package: {response.RootPackage.PackageName}");
                foreach (var entry in response.RootPackage.InnerPackages[0].PackageProperties)
                {
                    Console.WriteLine($"{entry.Name}: {entry.Value}");
                    if (entry.Tags == null) continue;
                    foreach (var tag in entry.Tags)
                    {
                        Console.WriteLine($"Tag for property: name - {tag.Name}, category - {tag.Category}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling InfoApi: " + e.Message);
            }
        }
    }
}