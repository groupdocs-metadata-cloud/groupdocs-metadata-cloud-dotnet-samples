using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.SetMetadata
{
    /// <summary>
    /// This example demonstrates how to set metadata by property value.
    /// </summary>
    public class SetMetadataByPropertyValue
    {
        public static void Run()
        {
            Console.WriteLine("Running SetMetadataByPropertyValue");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new SetOptions
                {
                    FileInfo = fileInfo,
                    Properties = new List<SetProperty>
                    {
                        new SetProperty
                        {
                            NewValue = "Microsoft Office Word Application",
                            Type = "String",
                            SearchCriteria = new SearchCriteria
                            {
                                ValueOptions = new ValueOptions
                                {
                                    Value = "Microsoft Office Word",
                                    Type = "String"
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