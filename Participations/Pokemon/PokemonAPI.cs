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
        public List<AllResults> results { get; set; }
    }

    public class AllResults
    {
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1);
        }
    }


    public class PokemonInfo
    {
        public int height { get; set; }
        public int weight { get; set; }

        public Sprite sprites { get; set; }

        public PokemonInfo()
        {
            height = 0;
            weight = 0;
            sprites = new Sprite();
        }

    }

    public class Sprite
    {
        public string front_default { get; set; }
        public string back_default { get; set; }


    }
}
