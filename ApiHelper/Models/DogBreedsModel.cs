using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiHelper.Models
{
    public class DogBreedsModel
    {
        [JsonProperty("message")]
        public Dictionary<string, List<string>> DogBreeds;
    }
}
