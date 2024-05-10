using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI songPrefab;
    public GameObject listParent;
    private DataManager dataManager;
    private List<TextMeshProUGUI> songListUI;


    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        songListUI = new List<TextMeshProUGUI>();
    }


    public void GenerateSongList(List<string> songBank)
    {
        foreach (var song in songBank)
        {
            var songInList = Instantiate(songPrefab, listParent.transform);

            songInList.text = song;
            songListUI.Add(songInList.GetComponent<TextMeshProUGUI>());
            songInList.colorGradient = ColorManager.instance.defaultGradient;
        }
        CheckForSongsPlayed();
        CheckForSongsExcluded();
    }


    public void CheckForSongsPlayed()
    {
        foreach (Song song in dataManager.songData)
        { if (song.songPlayed) MarkAsPlayed(song.title); }
    }


    public void MarkAsPlayed(string song)
    {
        for (int i = 0; i < songListUI.Count; i++)
        {
            if (song == songListUI[i].text)
            {
                songListUI[i].colorGradient = ColorManager.instance.playedGradient;
                break;
            }
        }
    }


    public void CheckForSongsExcluded()
    {
        foreach (Song song in dataManager.songData)
        { if (song.excluded) MarkAsExcluded(song.title); }
    }



    public void MarkAsExcluded(string song)
    {
        for (int i = 0; i < songListUI.Count; i++)
        {
            if (song == songListUI[i].text)
            {
                songListUI[i].colorGradient = ColorManager.instance.ExcludedColor();
                break;
            }
        }
    }



    public void ResetList()
    {
        for (int i = 0; i < songListUI.Count; i++)
        {
            songListUI[i].colorGradient = ColorManager.instance.DefaultColor();
        }
    }

}
