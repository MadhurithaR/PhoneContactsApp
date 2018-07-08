using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PhoneContactsApp
{
    public static class FileHelper
    {
 

        public static async Task<string> WriteTextFile(string filename, string contents)
        {

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.CreateFileAsync(filename,
               CreationCollisionOption.ReplaceExisting);

            using (IRandomAccessStream textStream = await
               textFile.OpenAsync(FileAccessMode.ReadWrite))
            {

                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(contents);
                    await textWriter.StoreAsync();
                }
            }

            return textFile.Path;
        }

        // Read the contents of a text file from the app's local folder.

        public static async Task<string> ReadTextFile(string filename)
        {
            string contents;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync(filename);

            using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
            {

                using (DataReader textReader = new DataReader(textStream))
                {
                    uint textLength = (uint)textStream.Size;
                    await textReader.LoadAsync(textLength);
                    contents = textReader.ReadString(textLength);
                }

            }

            return contents;
        }

       
    }

   
}
