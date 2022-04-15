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

        public static async Task<WordDefinition> GetWordDefinitionAsync(string RequestedWord)
        {
            using var Client = new HttpClient();
            var Data = await Client.GetStringAsync(GetRequestAddress(RequestedWord));
            
            return WordDefinition.FromJson(Data);
        }
    }
}