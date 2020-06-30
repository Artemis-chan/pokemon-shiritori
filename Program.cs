using System;
using Artemis.PokemonShiritori;

namespace pokemon_shiritori
{
    class Program
    {
        static void Main(string[] args)
        {
            var mgr = new PokeShiriManager();
            Console.WriteLine($"Name a pokemon name that starts with {mgr.nextChar}");
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
                        Console.WriteLine("No such pokemon exists");
                        break;
                    default:
                        Console.WriteLine($"Name a pokemon name that starts with {mgr.nextChar}");
                        break;
                }
            }
        }
    }
}
