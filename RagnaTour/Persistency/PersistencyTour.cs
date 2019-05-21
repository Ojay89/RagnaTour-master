using Newtonsoft.Json;
using RagnaTour.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace RagnaTour.Persistency
{
    public class PersistencyTour
    {
        private const string FileName = "Tour.json";
        private CreationCollisionOption _options;
        private StorageFolder _folder;

        public PersistencyTour()
        {
            _options = CreationCollisionOption.OpenIfExists;

            /* Firstly we will use StorageFolder class from the Windows.Storage namespace
            to get path to the LocalFolder for our application: */
            _folder = ApplicationData.Current.LocalFolder;
        }

        public async Task SaveAsync(List<Display> data)
        {
            /* Then we need to have reference to the file where we can store courses:
             Note that if file exists we do not want to create another one: */
            var dataFile = await _folder.CreateFileAsync(FileName, _options);

            // Now we want to serialize course list to save it in the JSON format in the file:
            string dataJSON = JsonConvert.SerializeObject(data);

            // Last step is to write serialized list of courses to the text file:
            await FileIO.WriteTextAsync(dataFile, dataJSON);
        }

        public async Task<List<Display>> LoadAsync()
        {
            try
            {
                /* Firstly we will use StorageFolder class from the Windows.Storage namespace
                to get the specified file if it exists */
                StorageFile dataFile = await _folder.GetFileAsync(FileName);

                // Read serialized courses list from the file:
                string dataJSON = await FileIO.ReadTextAsync(dataFile);

                //Deserialize JSON list to the List<Course> and return it
                return (dataJSON != null) ?
                    JsonConvert.DeserializeObject<List<Display>>(dataJSON)
                    : new List<Display>();
            }
            catch (FileNotFoundException)
            {
                await SaveAsync(new List<Display>());
                return new List<Display>();
            }
        }
    }

}