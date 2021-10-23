using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localisationSystem : MonoBehaviour
{
    public enum Language
    {
        English,
        Russian
    }
    public static int LanguageIndex = 0;

    public static Language language = Language.English;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedRU;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedRU = csvLoader.GetDictionaryValues("ru");

        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if(!isInit) { Init(); }
        string value = key;
        switch(language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                LanguageIndex = 0;
                break;
            case Language.Russian:
                localisedRU.TryGetValue(key, out value);
                LanguageIndex = 1;
                break;

        }
        return value;
    }
}
