using DictionaryApiNet;

var WordData = await DictionaryApi.GetWordDefinitionAsync("greeting");

Console.WriteLine($"{WordData.Word} [{WordData.Phonetics[0].Text}] - {WordData.Meanings[0].Definitions[0].DefinitionText}");
Console.ReadKey();