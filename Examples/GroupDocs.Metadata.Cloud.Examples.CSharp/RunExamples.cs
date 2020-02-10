using GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.AddMetadata;
using System;
using GroupDocs.Metadata.Cloud.Examples.CSharp.InfoOperations;
using GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.ExtractMetadata;
using GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.RemoveMetadata;
using GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.SetMetadata;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp
{
    public class RunExamples
    {
        public static void Main(string[] args)
        {
            //// ***********************************************************
            ////          GroupDocs.Metadata Cloud API Examples
            //// ***********************************************************

            //TODO: Get your AppSID and AppKey at https://dashboard.groupdocs.cloud (free registration is required).
            Common.MyAppSid = "xxxxxxxxxxxx";
            Common.MyAppKey = "xxxxxxxxxxxx";
            Common.MyStorage = "xxxxxxxxxxx";

            // Uploading sample test files from local disk to cloud storage
            Common.UploadSampleTestFiles();

            #region Info operations

            GetSupportedFileTypes.Run();

            //GetDocumentInformation.Run();

            //GetMetadataTagsInformation.Run();

            #endregion

            #region Metadata operations

            #region Add metadata

            //AddMetadataByTag.Run();

            //AddMetadataByPossibleTagName.Run();

            //AddMetadataByPropertyName.Run();

            //AddMetadataByPropertyNameMatchExactPhrase.Run();

            //AddMetadataByPropertyNameMatchRegex.Run();

            #endregion

            #region Extract metadata

            //ExtractWholeMetadataTree.Run();

            //ExtractMetadataByTag.Run();

            //ExtractMetadataByPossibleTagName.Run();

            //ExtractMetadataByPropertyName.Run();

            //ExtractMetadataByPropertyNameMatchExactPhrase.Run();

            //ExtractMetadataByPropertyNameMatchRegex.Run();

            //ExtractMetadataByPropertyValue.Run();

            #endregion

            #region Remove metadata

            //RemoveMetadataByTag.Run();

            //RemoveMetadataByPossibleTagName.Run();

            //RemoveMetadataByPropertyName.Run();

            //RemoveMetadataByPropertyNameMatchExactPhrase.Run();

            //RemoveMetadataByPropertyNameMatchRegex.Run();

            //RemoveMetadataByPropertyValue.Run();


            #endregion

            #region Set metadata

            //SetMetadataByTag.Run();

            //SetMetadataByPossibleTagName.Run();

            //SetMetadataByPropertyName.Run();

            //SetMetadataByPropertyNameMatchExactPhrase.Run();

            //SetMetadataByPropertyNameMatchRegex.Run();

            //SetMetadataByPropertyValue.Run();

            #endregion

            #endregion

            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
    }
}