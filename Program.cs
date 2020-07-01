using System;
using Artemis.PokemonShiritori;

namespace pokemon_shiritori
{
    class Program
    {
        static void Main(string[] args)
        {
            var mgr = new PokeShiriManager();
            Console.WriteLine($"Let's play Pokémon Shiritori!\nName a pokemon name that starts with {mgr.nextChar}");
            while (true)
            {
                Console.Write("> ");
                var res = mgr.Say(Console.ReadLine());
                switch (res)
                {
                    case Result.AlreadySaid:
                        Console.WriteLine("Name already said");
                        break;
                    case Result.WrongInitial:
                        Console.WriteLine("Wrong initial");
                        break;
                    case Result.NoPokemon:
                        Console.WriteLine("No such Pokémon exists");
                        break;
                    case Result.Finish:
                        Console.WriteLine("Game ended");
                        return;
                    default:
                        Console.WriteLine($"Name a Pokémon name that starts with {mgr.nextChar}");
                        break;
                }
            }
        }
    }
}
