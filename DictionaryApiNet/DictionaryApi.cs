using System.Net;
using DictionaryApiNet.Model;

namespace DictionaryApiNet
{
    public static class DictionaryApi
    {
        private static string GetRequestAddress(string RequestedWord)
        {
            return $"https://api.dictionaryapi.dev/api/v2/entries/en/{RequestedWord}";
        }

        public static WordDefinition GetWordDefinition(string Word)
        {
            return GetWordDefinitionAsync(Word).Result;
        }

        public static async Task<WordDefinition> GetWordDefinitionAsync(string Word)
        {
            using var Client = new HttpClient();
            var Data = await Client.GetStringAsync(GetRequestAddress(Word));
            
            return WordDefinition.FromJson(Data);
        }
    }
}