using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.RemoveMetadata
{
    /// <summary>
    /// This example demonstrates how to remove metadata by match property name regex.
    /// </summary>
    public class RemoveMetadataByPropertyNameMatchRegex
    {
        public static void Run()
        {
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new RemoveOptions
                {
                    FileInfo = fileInfo,
                    SearchCriteria = new SearchCriteria
                    {
                        NameOptions = new NameOptions
                        {
                            Value = "^[N]ame[A-Z].*",
                            MatchOptions = new MatchOptions
                            {
                                IsRegex = true
                            }
                        }
                    }
                };

                var request = new RemoveRequest(options);

                var response = apiInstance.Remove(request);
                Console.WriteLine("Resultant file path: " + response.Path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling MetadataApi: " + e.Message);
            }
        }
    }
}