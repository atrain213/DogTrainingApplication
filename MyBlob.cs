using Azure.Storage;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class MyBlob
    {
        private readonly static string _endpoint = "https://dogblobstorage.blob.core.windows.net/images/";
        private readonly static string _account = "dogblobstorage";
        private readonly static string _key = "20YQPpZ7idyP398qUlyle5yeoExcHRiIAE/7iGE91vpBBevaMK6MERXIlixfH1DbpFC325+EV6tv+AStAtpCPQ==";
        private readonly static StorageSharedKeyCredential _credential = new(_account,_key);

        public static Uri UploadImage(Stream stream, string filename)
        {
            Uri uri = new(_endpoint +  filename);
            BlobClient client = new BlobClient(uri, _credential);
            stream.Position = 0;
            client.Upload(stream, overwrite: true);
            return uri;
        }

        public static Uri ImageFile(string filename)
        {
            return new Uri(_endpoint + filename.ToLower());
        }

        public static Uri ImageFile(Guid gid, int type)
        {
            string ext = ".png";
            switch (type)
            {
                case 2:
                    ext = ".jpg";
                    break;
                default:
                    break;
            }
            string filename = gid.ToString().ToLower() + ext;
            return new Uri(_endpoint + filename);
        }
    }
}
