using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupManager : MonoBehaviour
{
    [Header("Popup Windows")]
    public GameObject mainPopup;
    public GameObject songDataPopup;
    public GameObject listPanel;
    public GameObject editorPanel;

    [Header("Main Popup")]
    public Image albumArt;
    public TextMeshProUGUI songTitle;

    [Header("Data Popup")]
    public TextMeshProUGUI songTitleData;
    public TextMeshProUGUI playCount;
    public TextMeshProUGUI lastPlayed;

    private bool popupActive = true;
    private bool editorActive;


    private void Start()
    { 
        OpenClosePopup(); 
    }

   
    public void OpenClosePopup()
    {
        popupActive = !popupActive;
        mainPopup.SetActive(popupActive);
        listPanel.SetActive(!popupActive);
        editorPanel.SetActive(false);
        songDataPopup.SetActive(false);
    }


    public void OpenCloseEditor()
    {
        editorActive = !editorActive;
        editorPanel.SetActive(editorActive);
        listPanel.SetActive(!editorActive);
        songDataPopup.SetActive(false);
    }


    public void SetPopupContent(string song)
    {
        songTitle.text = song;
        albumArt.sprite = AlbumArtManager.instance.GetAlbumArt(song);
    }

    public void SetDataPopupContent(Song chosenSong)
    {
        if(chosenSong == null) return;

        songTitleData.text = chosenSong.title;
        playCount.text = chosenSong.playCount.ToString();
        lastPlayed.text = chosenSong.lastPlayed;
    }


}

