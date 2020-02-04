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
                var options = new AddOptions
                {
                    FileInfo = fileInfo,
                    Properties = new List<AddProperty>
                    {
                        new AddProperty
                        {
                            Value = now,
                            Type = "DateTime",
                            SearchCriteria = new SearchCriteria
                            {
                                NameOptions = new NameOptions
                                {
                                    Value = "^.*print.*",
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling MetadataApi: " + e.Message);
            }
        }
    }
}