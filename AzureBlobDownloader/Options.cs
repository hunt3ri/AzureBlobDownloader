using CommandLine;

namespace AzureBlobDownloader
{
    public class Options
    {
        [Option("n", "accountname",  Required = true, HelpText = "Azure Blob Storage Account Name")]
        public string AccountName { get; set; }

        [Option("k", "key", Required = true, HelpText = "Azure Blob Storage Key")]
        public string AccountKey { get; set; }

        [Option("f", "filename", Required = true, HelpText = "Location where you want file downloaded to")]
        public string FileName { get; set; }

        [Option("c", "containername", Required = true, HelpText = "The name of the container containing the blob you want to download")]
        public string ContainerName { get; set; }

        [Option("b", "blobname", Required = true, HelpText = "The name of the blob you want to download")]
        public string BlobName { get; set; }

    }
}