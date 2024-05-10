using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SongEditor : MonoBehaviour
{
    public TextMeshProUGUI editorSongPrefab;
    public GameObject editorListParent;
    private DataManager dataManager;
    private List<TextMeshProUGUI> editorListUI;




    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        editorListUI = new List<TextMeshProUGUI>();
    }


    public void GenerateEditorList(List<string> songBank)
    {
        foreach (var song in songBank)
        {
            var songInList = Instantiate(editorSongPrefab, editorListParent.transform);

            songInList.text = song;
            editorListUI.Add(songInList.GetComponent<TextMeshProUGUI>());
        }

        CheckForSongsExcluded();
    }



    public void CheckForSongsExcluded()
    {
        foreach (Song song in dataManager.songData)
        { if (song.excluded) MarkAsExcluded(song.title); }
    }


    public void ResetEditorList()
    {
        foreach (var song in editorListUI)
        { MarkAsIncluded(song.text); }
    }


    public void MarkAsExcluded(string song)
    {
        for (int i = 0; i < editorListUI.Count; i++)
        {
            if (song == editorListUI[i].text)
            {
                editorListUI[i].colorGradient = ColorManager.instance.ExcludedColor();
                var data = dataManager.RetrieveSongData(song);
                data.excluded = true;

                break;
            }
        }
    }


    public void MarkAsIncluded(string song)
    {
        for (int i = 0; i < editorListUI.Count; i++)
        {
            if (song == editorListUI[i].text)
            {
                editorListUI[i].colorGradient = ColorManager.instance.DefaultColor();
                var data = dataManager.RetrieveSongData(song);
                data.excluded = false;

                break;
            }
        }
    }


}
