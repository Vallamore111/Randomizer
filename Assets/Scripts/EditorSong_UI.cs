using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditorSong_UI : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    private SongEditor songEditor;
    private DataManager dataManager;
    public static GameObject clickedSongUI;


    private void Awake()
    {
        songEditor = FindObjectOfType<SongEditor>();
        dataManager = FindObjectOfType<DataManager>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        var clickedSong = gameObject.GetComponent<TextMeshProUGUI>().text;
        var data = dataManager.RetrieveSongData(clickedSong);

        if (!data.excluded)
        { songEditor.MarkAsExcluded(clickedSong); }
        else songEditor.MarkAsIncluded(clickedSong);
    }


    public void OnDrag(PointerEventData eventData)
    {
        var scrollRect = GetComponentInParent<ScrollRect>();
        eventData.pointerDrag = scrollRect.gameObject;
        EventSystem.current.SetSelectedGameObject(scrollRect.gameObject);

        scrollRect.OnInitializePotentialDrag(eventData);
        scrollRect.OnBeginDrag(eventData);
    }
}
