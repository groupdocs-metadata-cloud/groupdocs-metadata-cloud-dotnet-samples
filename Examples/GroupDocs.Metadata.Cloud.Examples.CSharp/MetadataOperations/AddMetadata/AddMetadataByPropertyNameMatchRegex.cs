using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.AddMetadata
{
    /// <summary>
    /// This example demonstrates how to add metadata by match property name regex.
    /// </summary>
    public class AddMetadataByPropertyNameMatchRegex
    {
        public static void Run()
        {
            Console.WriteLine("Running AddMetadataByPropertyNameMatchRegex");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new AddOptions
                {
                    FileInfo = fileInfo,
                    Properties = new List<AddProperty>
                    {
                        new AddProperty
                        {
                            Value = "Test User",
                            Type = "String",
                            SearchCriteria = new SearchCriteria
                            {
                                NameOptions = new NameOptions
                                {
                                    Value = "^.*manage.*",
                                    MatchOptions = new MatchOptions
                                    {
                                        IsRegex = true
                                    }
                                }
                            },
                        }
                    }
                };

                var request = new AddRequest(options);

                var response = apiInstance.Add(request);
                Console.WriteLine($"Count of changes: {response.AddedCount}");
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