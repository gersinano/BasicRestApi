using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class CreateDevice
    {

        [JsonProperty("name")]
        [Required]
        [MinLength(1, ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }
    }

    public class DataPair
    {

    }

}
