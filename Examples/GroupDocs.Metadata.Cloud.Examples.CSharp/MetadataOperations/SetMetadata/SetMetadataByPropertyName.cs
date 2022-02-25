using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.SetMetadata
{
    /// <summary>
    /// This example demonstrates how to set metadata by property name.
    /// </summary>
    public class SetMetadataByPropertyName
    {
        public static void Run()
        {
            Console.WriteLine("Running SetMetadataByPropertyName");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };
                var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                var options = new SetOptions
                {
                    FileInfo = fileInfo,
                    Properties = new List<SetProperty>
                    {
                        new SetProperty
                        {
                            NewValue = now,
                            Type = "DateTime",
                            SearchCriteria = new SearchCriteria
                            {
                                NameOptions = new NameOptions
                                {
                                    Value = "Date"
                                }
                            },
                        }
                    }
                };

                var request = new SetRequest(options);

                var response = apiInstance.Set(request);
                Console.WriteLine($"Count of changes: {response.SetCount}");
                Console.WriteLine("Resultant file path: " + response.Path);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling MetadataApi: " + e.Message + "\n");
            }
        }
    }
}