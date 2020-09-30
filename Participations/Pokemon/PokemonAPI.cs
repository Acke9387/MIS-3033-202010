using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class PokemonAPI
    {
        [JsonProperty("results")]
        public List<AllResults> Results { get; set; }
    }

    public class AllResults
    {
        public string name { get; set; }
        public string url { get; set; }
    }


}
