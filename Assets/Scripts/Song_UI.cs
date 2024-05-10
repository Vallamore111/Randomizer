using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Song_UI : MonoBehaviour, IPointerClickHandler, IDragHandler  
{
    private DataManager dataManager;
    private PopupManager popupManager;
    public static GameObject clickedSongUI;


    void Awake()
    {
        dataManager =  FindObjectOfType<DataManager>();
        popupManager = FindObjectOfType<PopupManager>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        var clickedSong = gameObject.GetComponent<TextMeshProUGUI>().text;
        var data = dataManager.RetrieveSongData(clickedSong);

        if (!popupManager.songDataPopup.activeInHierarchy)
        {
            clickedSongUI = gameObject;
            popupManager.songDataPopup.SetActive(true);
            popupManager.SetDataPopupContent(data);
        }
        else popupManager.songDataPopup.SetActive(false);

    }

    public void OnDrag(PointerEventData eventData)
    {
        var scrollRect = GetComponentInParent<ScrollRect>();
        eventData.pointerDrag = scrollRect.gameObject;
        EventSystem.current.SetSelectedGameObject(scrollRect.gameObject);

        scrollRect.OnInitializePotentialDrag(eventData);
        scrollRect.OnBeginDrag(eventData);

        popupManager.songDataPopup.SetActive(false);
    }
}
