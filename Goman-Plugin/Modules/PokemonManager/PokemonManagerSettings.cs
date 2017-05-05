using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using POGOProtos.Enums;

namespace Goman_Plugin.Modules.PokemonManager
{
    public class PokemonManagerSettings
    {
        public int IntervalMilliseconds { get; set; } = 60000;
        public Dictionary<PokemonId, PokemonManager> Pokemons { get; } = new Dictionary<PokemonId, PokemonManager>();

        [JsonConstructor]
        public PokemonManagerSettings()
        {
        }

        public PokemonManagerSettings(bool newp)
        {
            foreach (PokemonId value in Enum.GetValues(typeof(PokemonId)))
            {
                Pokemons.Add(value, new PokemonManager(value));
            }
        }
    }

    public class PowerUpTable
    {
        public static  Dictionary<double, PowerUp> Table = new Dictionary<double, PowerUp>()
        {
           {1,new PowerUp(200,1)},
            {1.5,new PowerUp(200,1)},
            {2,new PowerUp(200,1)},
            {2.5,new PowerUp(200,1)},
            {3,new PowerUp(400,1)},
            {3.5,new PowerUp(400,1)},
            {4,new PowerUp(400,1)},
            {4.5,new PowerUp(400,1)},
            {5,new PowerUp(600,1)},
            {5.5,new PowerUp(600,1)},
            {6,new PowerUp(600,1)},
            {6.5,new PowerUp(600,1)},
            {7,new PowerUp(800,1)},
            {7.5,new PowerUp(800,1)},
            {8,new PowerUp(800,1)},
            {8.5,new PowerUp(800,1)},
            {9,new PowerUp(1000,1)},
            {9.5,new PowerUp(1000,1)},
            {10,new PowerUp(1000,1)},
            {10.5,new PowerUp(1000,1)},
            {11,new PowerUp(1300,2)},
            {11.5,new PowerUp(1300,2)},
            {12,new PowerUp(1300,2)},
            {12.5,new PowerUp(1300,2)},
            {13,new PowerUp(1600,2)},
            {13.5,new PowerUp(1600,2)},
            {14,new PowerUp(1600,2)},
            {14.5,new PowerUp(1600,2)},
            {15,new PowerUp(1900,2)},
            {15.5,new PowerUp(1900,2)},
            {16,new PowerUp(1900,2)},
            {16.5,new PowerUp(1900,2)},
            {17,new PowerUp(2200,2)},
            {17.5,new PowerUp(2200,2)},
            {18,new PowerUp(2200,2)},
            {18.5,new PowerUp(2200,2)},
            {19,new PowerUp(2500,2)},
            {19.5,new PowerUp(2500,2)},
            {20,new PowerUp(2500,2)},
            {20.5,new PowerUp(2500,2)},
            {21,new PowerUp(3000,3)},
            {21.5,new PowerUp(3000,3)},
            {22,new PowerUp(3000,3)},
            {22.5,new PowerUp(3000,3)},
            {23,new PowerUp(3500,3)},
            {23.5,new PowerUp(3500,3)},
            {24,new PowerUp(3500,3)},
            {24.5,new PowerUp(3500,3)},
            {25,new PowerUp(4000,3)},
            {25.5,new PowerUp(4000,3)},
            {26,new PowerUp(4000,4)},
            {26.5,new PowerUp(4000,4)},
            {27,new PowerUp(4500,4)},
            {27.5,new PowerUp(4500,4)},
            {28,new PowerUp(4500,4)},
            {28.5,new PowerUp(4500,4)},
            {29,new PowerUp(5000,4)},
            {29.5,new PowerUp(5000,4)},
            {30,new PowerUp(5000,4)},
            {30.5,new PowerUp(5000,4)},
            {31,new PowerUp(6000,6)},
            {31.5,new PowerUp(6000,6)},
            {32,new PowerUp(6000,6)},
            {32.5,new PowerUp(6000,6)},
            {33,new PowerUp(7000,8)},
            {33.5,new PowerUp(7000,8)},
            {34,new PowerUp(7000,8)},
            {34.5,new PowerUp(7000,8)},
            {35,new PowerUp(8000,10)},
            {35.5,new PowerUp(8000,10)},
            {36,new PowerUp(8000,10)},
            {36.5,new PowerUp(8000,10)},
            {37,new PowerUp(9000,12)},
            {37.5,new PowerUp(9000,12)},
            {38,new PowerUp(9000,12)},
            {38.5,new PowerUp(9000,12)},
            {39,new PowerUp(10000,15)},
            {39.5,new PowerUp(10000,15)},
            {40,new PowerUp(10000,15)},
            {40.5,new PowerUp(10000,15)}



        };
    }
    public class PowerUp
    {
        public int Stardust { get; set; }
        public int Candy { get; set; }

        public PowerUp(int stardust, int candy)
        {
            Stardust = stardust;
            Candy = candy;
        }
    }
    public class PokemonManager
    {
        public PokemonManager(PokemonId pokemonId)
        {
            PokemonId = pokemonId;
            PokemonName = pokemonId.ToString();
        }
        public string PokemonName { get; set; }
        public PokemonId PokemonId { get; set; }
        public int Quantity { get; set; } = 5;
        public int MinimumIv { get; set; } = 0;
        public int MinimumCp { get; set; } = 0;
        public bool AutoRenameWithIv { get; set; } = false;
        public bool AutoFavorite { get; set; } = false;
        public bool AutoUpgrade { get; set; } = false;
        public bool AutoEvolve { get; set; } = false;
    }
}
