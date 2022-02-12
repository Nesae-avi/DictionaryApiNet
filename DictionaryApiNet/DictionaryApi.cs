using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Net;

namespace DictionaryApiNet
{
    public class WordDefinition
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("phonetic")]
        public string Phonetic { get; set; }

        [JsonProperty("phonetics")]
        public Phonetic[] Phonetics { get; set; }

        [JsonProperty("origin", NullValueHandling = NullValueHandling.Ignore)]
        public string Origin { get; set; }

        [JsonProperty("meanings")]
        public Meaning[] Meanings { get; set; }

        public static WordDefinition[] FromJson(string json) => JsonConvert.DeserializeObject<WordDefinition[]>(json, Converter.Settings);
    }

    public class Meaning
    {
        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        [JsonProperty("definitions")]
        public Definition[] Definitions { get; set; }
    }

    public class Definition
    {
        [JsonProperty("definition")]
        public string DefinitionText { get; set; }

        [JsonProperty("synonyms")]
        public string[] Synonyms { get; set; }

        [JsonProperty("antonyms")]
        public object[] Antonyms { get; set; }

        [JsonProperty("example", NullValueHandling = NullValueHandling.Ignore)]
        public string Example { get; set; }
    }

    public class Phonetic
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("audio", NullValueHandling = NullValueHandling.Ignore)]
        public string Audio { get; set; }
    }

    public static class Serialize
    {
        public static string ToJson(this WordDefinition[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public static class DictionaryApi
    {
        private static string GetRequestLink(string RequestedWord)
        {
            return $"https://api.dictionaryapi.dev/api/v2/entries/en/{RequestedWord}";
        }

        public static WordDefinition GetWordDefinition(string RequestedWord)
        {
            using var Client = new WebClient();
            return WordDefinition.FromJson(Client.DownloadString(GetRequestLink(RequestedWord)))[0];
        }
    }
}