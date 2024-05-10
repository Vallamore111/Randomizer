using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    [Header("Color Palette")]
    public Color backgroundAlpha;
    public Color primaryColor;
    public Color secondaryColor;
    public VertexGradient defaultGradient;
    public VertexGradient playedGradient;
    public VertexGradient excludedGradient;
    public VertexGradient menuTextGradient;

    [Header("Objects")]
    public Image background;
    public Image logo;
    public Image songDataPopup;
    public Button[] buttonTexts;

    [Header("Menu Text")]
    public TMP_Text behold;
    public TMP_Text randomizerText;
    public TMP_Text songTitle;
    public TMP_Text songTitleData;
    public TMP_Text songListEditor;
    public TMP_Text playCount;
    public TMP_Text playCountData;
    public TMP_Text lastPlayed;
    public TMP_Text lastPlayedData;



    void Awake() => instance = this;
    void Start() => SetColors();


    void SetColors()
    {
        background.color = backgroundAlpha;
        logo.color = primaryColor;
        songListEditor.colorGradient = menuTextGradient;

        behold.colorGradient = menuTextGradient;
        randomizerText.colorGradient = menuTextGradient;
        songTitle.colorGradient = defaultGradient;

        songDataPopup.color = secondaryColor;
        songTitleData.colorGradient = defaultGradient;
        playCount.colorGradient = menuTextGradient;
        playCountData.colorGradient = defaultGradient;
        lastPlayed.colorGradient = menuTextGradient;
        lastPlayedData.colorGradient = defaultGradient;

        foreach (var button in buttonTexts)
        {
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            text.colorGradient = defaultGradient;
        }
    }


    public VertexGradient DefaultColor() 
    {
        return defaultGradient;
    }

    public VertexGradient PlayedColor()
    {
        return playedGradient;
    }

    public VertexGradient ExcludedColor()
    {
        return excludedGradient;
    }

}
