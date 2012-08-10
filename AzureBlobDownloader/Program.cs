using System;
using CommandLine;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureBlobDownloader
{
    class Program
    {

        static void Main(string[] args)
        {
            var settings = new CommandLineParserSettings();
            settings.CaseSensitive = false;
            settings.HelpWriter = Console.Error;
            ICommandLineParser parser = new CommandLineParser(settings);

            var options = new Options();
            //
            // create parser (with settings) here, see above
            //
            bool success = parser.ParseArguments(args, options);
            if (success)
            {
                Console.WriteLine("Successfully parsed args, attempting to download blob");
            }
            else
            {
                throw new ArgumentException("Unable to parse args");
            }

            DownloadFile(options);
        }


        private static string BuildConnectionString(Options options)
        {
            string connectionstring = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                                        options.AccountName, options.AccountKey);


            return connectionstring;
        }

        private static void DownloadFile(Options options)
        {
            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(BuildConnectionString(options));
            
             //Create the blob client
             CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            
             //Retrieve reference to a previously created container
             CloudBlobContainer container = blobClient.GetContainerReference(options.ContainerName);
            
            // Retrieve reference to a blob named "myblob"
              CloudBlob blob = container.GetBlobReference(options.BlobName);
            
             //Save blob contents to disk
             using (var fileStream = System.IO.File.OpenWrite(@options.FileName))
             {
                 blob.DownloadToStream(fileStream);
             }
        }
    }


}
