using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public List<string> songBank;
    private UIManager uiManager;
    private PopupManager popupManager;
    private DataManager dataManager;
    private SongEditor songEditor;
    public static string songCache;


    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        popupManager = FindObjectOfType<PopupManager>();
        dataManager = FindObjectOfType<DataManager>();
        songEditor = FindObjectOfType<SongEditor>();

        songBank = new List<string>();
    }


    private void Start()
    {
        PopulateSongList();
        dataManager.LoadSongData(songBank);
        uiManager.GenerateSongList(songBank);
        songEditor.GenerateEditorList(songBank);
        RememberSongs();
    }


    public void PopulateSongList()
    {
        songBank.Add("Firestorm");
        songBank.Add("Marching On");
        songBank.Add("The Gorgon");
        songBank.Add("Eternal Night");
        songBank.Add("Fallen Glory");
        songBank.Add("Shadow Queen");
        songBank.Add("Kingdom Come");
        songBank.Add("Fighting Onward");

        songBank.Add("Bringer of Fire");
        songBank.Add("The Contract");
        songBank.Add("Sword and Shield");
        songBank.Add("Divided We Fall");
        songBank.Add("Orpheus");
        songBank.Add("Vengeance Rising");
        songBank.Add("Our Great Defender");

        songBank.Add("Gates of Evermore");
        songBank.Add("Honor Bound");
        songBank.Add("Seekers of the Blade");
        songBank.Add("Blood Red Cross");
        songBank.Add("On Ashen Wings");
        songBank.Add("Graves of Thunder");
        songBank.Add("Grace and Valor");
        songBank.Add("Night Queen");
        songBank.Add("The Serpent and the Throne");
        songBank.Add("Horns Held High");

        songBank.Add("Everlasting Fire");
        songBank.Add("Under the Spell");
        songBank.Add("Kingdom of Lies");
        songBank.Add("A Funeral Within");
        songBank.Add("Ready to Strike");
        songBank.Add("The Phantom Flame");
        songBank.Add("A Curse Upon Mankind");
        songBank.Add("Where Madness Dwells");
        songBank.Add("Infernal Angels");
        songBank.Add("Sands of Time");

        songBank.Add("Blood and Honor");
        songBank.Add("Soul Survivors");
        songBank.Add("Majesty of Steel");
        songBank.Add("Mistress of Desire");
        songBank.Add("Standing Tall");
        songBank.Add("Sword of a Thousand Truths");
        songBank.Add("Riding the Dragons");
        songBank.Add("Shadow of the Reaper");
        songBank.Add("Cold Flesh Falls");
        songBank.Add("Exile of the Sun");

        songBank.Add("Queen of Thorns");
        songBank.Add("Wolfen");
        songBank.Add("Moonchild");
        songBank.Add("Shoot Out the Lights");
        songBank.Add("Man on a Silver Mountain");
        songBank.Add("Leather Rebel");
        songBank.Add("Stay Hungry");
        songBank.Add("Storm Crusher");
        songBank.Add("Strange Wings");
        songBank.Add("One Night in Essen");
    }


    public void GetRandomSong() 
    {
        if (songBank.Count > 0)
        {
            songCache = songBank[Random.Range(0, songBank.Count)];
            MarkAsPlayed(songCache);
        }
        dataManager.UpdateSongData();
    }


    public void MarkAsPlayed(string song)
    {
        for (int i = 0; i < songBank.Count; i++)
        {
            if (song == songBank[i])
            {
                songBank.RemoveAt(i);
                uiManager.MarkAsPlayed(song);
                popupManager.SetPopupContent(song);
                break;
            }
        }
    }


    public void MarkAsExcluded(string song)
    {
        for (int i = 0; i < songBank.Count; i++)
        {
            if (song == songBank[i])
            {
                songBank.RemoveAt(i);
                uiManager.MarkAsExcluded(song);
                break;
            }
        }
    }


    public void RememberSongs()
    {
        foreach (Song song in dataManager.songData)
        {
            if (song.songPlayed)
            { MarkAsPlayed(song.title); }

            if (song.excluded)
            { MarkAsExcluded(song.title); }
        }
    }


    public void UndoExclusion()
    {
        foreach (Song song in dataManager.songData)
        {
            if (!songBank.Contains(song.title) && !song.excluded && !song.songPlayed)
            { songBank.Add(song.title); }
        }
    }


    public void ResetSongLists()
    {
        songBank.Clear();
        PopulateSongList();
        uiManager.ResetList();
        dataManager.ClearPlayedSongs();
        RememberSongs();
        popupManager.songDataPopup.SetActive(false);
    }

}
