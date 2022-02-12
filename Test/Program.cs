using DictionaryApiNet;

var WordData = DictionaryApi.GetWordDefinition("Cat");

Console.WriteLine($"{WordData.Word} [{WordData.Phonetics[0].Text}] - {WordData.Meanings[0].Definitions[0].DefinitionText}");
Console.ReadKey();