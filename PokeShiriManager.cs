using System;
using System.Collections.Generic;
using System.IO;

namespace Artemis.PokemonShiritori
{
    public enum Result
    {
        Done,
        WrongInitial,
        AlreadySaid,
        NoPokemon,
        Finish
    }

    public class PokeShiriManager
    {
        private static Dictionary<char, List<string>> _namesList;

        private Dictionary<char, List<string>> _saidList = new Dictionary<char, List<string>>();
        
        public char nextChar;

        public PokeShiriManager()
        {
            SetRandomInit();
            //nextChar = 'a';

            for (char c = 'a'; c <= 'z'; c++)
            {
                _saidList.Add(c, new List<string>());
            }

            if(_namesList == null)
            {
                FillDictionary();
            }
        }

        public Result Say(string name)
        {
            name = name.ToLower().Trim();
            if(name[0] != nextChar)
                return Result.WrongInitial;
            if(_saidList[nextChar].Contains(name))
                return Result.AlreadySaid;
            if(!_namesList[nextChar].Contains(name))
                return Result.NoPokemon;

            _saidList[nextChar].Add(name);

            /*nextChar = name[name.Length - 1];
            for (int i = 2; !InitAvailable(nextChar); i++)
            {
                nextChar = name[name.Length - i];

                if (i > name.Length)
                    return Result.Finish;
            }*/

            /*{
                int i = 1;
                do
                {
                    nextChar = name[name.Length - i];
                    i++;

                    if(i > name.Length)
                        return Result.Finish;

                } while(!InitAvailable(nextChar));
            }*/
            for (int i = 1; i <= name.Length; i++)
            {
                nextChar = name[name.Length - i];

                if(InitAvailable(nextChar))
                    return Result.Done;
            }

            return Result.Finish;
        }

        public void SetRandomInit()
        {
            nextChar = (char)new Random().Next(0x61, 0x7b);
        }

        private bool InitAvailable(char init) =>
            (_namesList[init].Count > _saidList[init].Count);

        private static void FillDictionary()
        {
            _namesList = new Dictionary<char, List<string>>();
            var names = File.ReadAllLines("pokemonlist.txt");

            int nameIndex = 0;
            for (char c = 'a'; c <= 'z'; c++)
            {
                var temp = new List<string>();
                for(; nameIndex < names.Length && names[nameIndex][0] == c; nameIndex++)
                {
                    temp.Add(names[nameIndex]);
                }
                _namesList.Add(c, temp);
            }
        }
        
    }
}