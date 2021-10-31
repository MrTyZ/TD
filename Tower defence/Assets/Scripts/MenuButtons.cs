using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MenuButtons : MonoBehaviourPun
{
    public GameObject InfintySelector;
    public GameObject Main;
    public GameObject setting;
    public GameObject Trials;
    public GameObject Multiplayer;
    public GameObject Stats;
    public GameObject Background;
    public static int countmap = 5;
    public static string[] MapArrayString = new string[countmap];
    public static int SelectArray=0;
    public static bool DebugMod = false;
    public static int trialsCounterEnd = 3;


    
    void Start()
    {
        PhotonView photonView = PhotonView.Get(this);
        Time.timeScale = 1;
            InfintySelector.SetActive(true);
            Main.SetActive(true);
            setting.SetActive(true);
            Trials.SetActive(true);
            Multiplayer.SetActive(true);
            Stats.SetActive(true);
            //Загрузка натсроек из реестра
            Background.GetComponent<RawImage>().enabled = true;
            if (PlayerPrefs.GetInt("language") == 0) { localisationSystem.language = localisationSystem.Language.English;
            GameObject.Find("TextLanguage").GetComponent<Text>().text = "Language: English"; }
            else { localisationSystem.language = localisationSystem.Language.Russian;
            GameObject.Find("TextLanguage").GetComponent<Text>().text = "Язык: Русский"; }

            trialsCounterEnd = PlayerPrefs.GetInt("Trial");
            for (int i = 0; i < trialsCounterEnd; i++)
            { GameObject.Find((i+1).ToString()).GetComponent<Button>().interactable = true;}
            


       
            TextLoaderUI.swap = true;
            for (int i = 0; i < countmap; i++)
            { MapArrayString[i] = "Map" + (i + 1); }
        if (trialsCounterEnd > 8) {
            GameObject.Find("InfinityText").GetComponent<Text>().enabled = true;
            GameObject.Find("InfintyImage").GetComponent<RawImage>().enabled = true;
        }
        else { GameObject.Find("InfinityText").GetComponent<Text>().enabled = false;
               GameObject.Find("InfintyImage").GetComponent<RawImage>().enabled = false;
        }
        StartCoroutine(PauseForMenu());



    }
      
    
    public void swapmapinfinity()
    {
            GameObject.Find("MainMap").GetComponent<RawImage>().texture = Resources.Load<Texture>("Photo/" + MapArrayString[SelectArray]);
        if (SelectArray - 1 < 0) { GameObject.Find("Map1").GetComponent<RawImage>().texture = Resources.Load<Texture>("Photo/" + MapArrayString[countmap - 1]); }
        else { GameObject.Find("Map1").GetComponent<RawImage>().texture = Resources.Load<Texture>("Photo/" + MapArrayString[SelectArray - 1]); }
        if (SelectArray + 1 > countmap-1)
        { GameObject.Find("Map2").GetComponent<RawImage>().texture = Resources.Load<Texture>("Photo/" + MapArrayString[0]); }
        else
        {
            GameObject.Find("Map2").GetComponent<RawImage>().texture = Resources.Load<Texture>("Photo/" + MapArrayString[SelectArray + 1]);
        }
         }
    public void LeftSelectInfinity()
    {
        if (globalvariable.online)
        { photonView.RPC("Decrease", RpcTarget.All, null); }
        else {
            SelectArray--;
            if (SelectArray < 0) { SelectArray = countmap - 1; }
        }
        
       
        swapmapinfinity();
        
    }
    [PunRPC]
    private void Decrease()
    {
        SelectArray--;
        if (SelectArray < 0) { SelectArray = countmap - 1; }
    }
    public void RightSelectInfinity()
    {
        if (globalvariable.online) { photonView.RPC("Increase", RpcTarget.All, null); }
        else
        {
            SelectArray++;
            if (SelectArray > countmap - 1) { SelectArray = 0; }
        }
        
        swapmapinfinity();
       
    }
    [PunRPC]
    private void Increase()
    {
        SelectArray++;
        if (SelectArray > countmap - 1) { SelectArray = 0; }
    }
   
    public void Infinity()
    {
        Main.SetActive(false);
        InfintySelector.SetActive(true);
        SelectArray = 0;
        swapmapinfinity();
    }
    public void esc()
    {
        InfintySelector.SetActive(false);
        Main.SetActive(true);
        setting.SetActive(false);
        Trials.SetActive(false);
        Multiplayer.SetActive(false);
        Stats.SetActive(false);
    }
    public void Exit()
    {
        print("Exit");
        Application.Quit();
    }
    public void Setting()
    {
        Main.SetActive(false);
        setting.SetActive(true);
    }
    public void stats()
    {
        Main.SetActive(false);
        Stats.SetActive(true);
        GameObject.Find("TextWave").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("maxwave") + PlayerPrefs.GetInt("maxwave");
        GameObject.Find("TextWave1").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("maxwave") + PlayerPrefs.GetInt("maxwave1");
        GameObject.Find("TextWave2").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("maxwave") + PlayerPrefs.GetInt("maxwave2");
        GameObject.Find("TextWave3").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("maxwave") + PlayerPrefs.GetInt("maxwave3");
        GameObject.Find("TextWave4").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("maxwave") + PlayerPrefs.GetInt("maxwave4");
        GameObject.Find("TextWave5").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("maxwave") + PlayerPrefs.GetInt("maxwave5");
        if ((PlayerPrefs.GetInt("Trial") - 1 < 0)) { GameObject.Find("TextCounterTrial").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("counttrial") + 0 + "/32"; }
        else { GameObject.Find("TextCounterTrial").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("counttrial") + (PlayerPrefs.GetInt("Trial") - 1) + "/32"; }
    }
    public void Trial()
    {
        Main.SetActive(false);
        Trials.SetActive(true);
    }
    public void DegubMod()
    {
        if (!DebugMod)
        {
            DebugMod = true; GameObject.Find("TextDebug").GetComponent<Text>().text = "Debugging mode: On"; Gold.gold_start = 1000000;
            Trials.SetActive(true);
            Background.GetComponent<RawImage>().enabled = true;
            for (int i = 0; i < 32; i++)
            { GameObject.Find((i + 1).ToString()).GetComponent<Button>().interactable = true; }
            Trials.SetActive(false);
            Main.SetActive(true);
            GameObject.Find("InfinityText").GetComponent<Text>().enabled = true;
            GameObject.Find("InfintyImage").GetComponent<RawImage>().enabled = true;
            Main.SetActive(false);
            Background.GetComponent<RawImage>().enabled = false;
            
        }
        else
        {
            DebugMod = false; GameObject.Find("TextDebug").GetComponent<Text>().text = "Debugging mode: Off"; Gold.gold_start = 100;
            Trials.SetActive(true);
            Background.GetComponent<RawImage>().enabled = true;
            for (int i = 0; i < 32; i++)
            { GameObject.Find((i + 1).ToString()).GetComponent<Button>().interactable = false; }
            for (int i = 0; i < trialsCounterEnd; i++)
            { GameObject.Find((i + 1).ToString()).GetComponent<Button>().interactable = true; }
            Trials.SetActive(false);
            Main.SetActive(true);
            if (trialsCounterEnd > 8)
            {
                GameObject.Find("InfinityText").GetComponent<Text>().enabled = true;
                GameObject.Find("InfintyImage").GetComponent<RawImage>().enabled = true;
            }
            else
            {
                GameObject.Find("InfinityText").GetComponent<Text>().enabled = false;
                GameObject.Find("InfintyImage").GetComponent<RawImage>().enabled = false;
            }
            Main.SetActive(false);
            Background.GetComponent<RawImage>().enabled = false;
        }
    }
   
    public void multiplayer()
    {
        Main.SetActive(false);
        Multiplayer.SetActive(true);
    }
    public void Language()
    {
        if (localisationSystem.language==0) { localisationSystem.language = localisationSystem.Language.Russian; GameObject.Find("TextLanguage").GetComponent<Text>().text = "Язык: Русский"; }
        else { localisationSystem.language = localisationSystem.Language.English; GameObject.Find("TextLanguage").GetComponent<Text>().text = "Language: English"; }
        Background.GetComponent<RawImage>().enabled = true;
        InfintySelector.SetActive(true);
        Main.SetActive(true);
        TextLoaderUI.swap = true;
        StartCoroutine(PauseForLanguage());
        
    }
    IEnumerator PauseForMenu()
    {
            yield return new WaitForSeconds(0.1f);
            InfintySelector.SetActive(false);
            Background.GetComponent<RawImage>().enabled = false;
            setting.SetActive(false);
            Trials.SetActive(false);
            Multiplayer.SetActive(false);
            Stats.SetActive(false);
            TextLoaderUI.swap = false;
    }
    IEnumerator PauseForLanguage()
    {
        yield return new WaitForSeconds(0.1f);
        InfintySelector.SetActive(false);
        Background.GetComponent<RawImage>().enabled = false;
        Main.SetActive(false);
        Trials.SetActive(false);
        Multiplayer.SetActive(false);
        Stats.SetActive(false);
        TextLoaderUI.swap = false;
    }
    public void UpdateMenu()
    {
        InfintySelector.SetActive(false);
        Background.GetComponent<RawImage>().enabled = false;
        setting.SetActive(false);
        Trials.SetActive(false);
        Multiplayer.SetActive(false);
        Stats.SetActive(false);
        TextLoaderUI.swap = false;
    }
    public void SaveSetting()
    {
        PlayerPrefs.SetInt("language", localisationSystem.LanguageIndex);
        
    }
}
