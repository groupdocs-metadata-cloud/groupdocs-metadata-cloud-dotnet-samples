using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using System;
using System.IO;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp
{
    internal class Common
    {
        public static string MyAppSid;
        public static string MyAppKey;
        public static string MyStorage;

        public static void UploadSampleTestFiles()
        {
            var storageConfig = new Configuration(MyAppSid, MyAppKey);
            var storageApi = new StorageApi(storageConfig);
            var folderApi = new FolderApi(storageConfig);
            var fileApi = new FileApi(storageConfig);

            var path = "..\\..\\..\\Resources";

            Console.WriteLine("File Upload Processing...");

            var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach (var dir in dirs)
            {
                var relativeDirPath = dir.Replace(path, string.Empty).Trim(Path.DirectorySeparatorChar);
                var response = storageApi.ObjectExists(new Sdk.Model.Requests.ObjectExistsRequest(relativeDirPath, MyStorage));
                if (response.Exists != null && !response.Exists.Value)
                {
                    folderApi.CreateFolder(new Sdk.Model.Requests.CreateFolderRequest(relativeDirPath, MyStorage));
                }
            }

            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var relativeFilePath = file.Replace(path, string.Empty).Trim(Path.DirectorySeparatorChar);

                var response = storageApi.ObjectExists(new Sdk.Model.Requests.ObjectExistsRequest(relativeFilePath, MyStorage));
                if (response.Exists != null && !response.Exists.Value)
                {
                    var fileStream = File.Open(file, FileMode.Open);

                    fileApi.UploadFile(new Sdk.Model.Requests.UploadFileRequest(relativeFilePath, fileStream, MyStorage));
                    fileStream.Close();
                }
            }

            Console.WriteLine("File Upload Process Completed.");
        }
    }
}