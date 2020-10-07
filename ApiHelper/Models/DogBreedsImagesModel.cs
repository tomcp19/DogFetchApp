using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiHelper.Models
{
    class DogBreedsImagesModel
    {
        [JsonProperty("message")]
        public List<string> DogBreedsImages;
    }
}
