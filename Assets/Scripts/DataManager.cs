using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<Song> songData;


    private void Awake() => songData = new List<Song>();

    public void LoadSongData(List<string> songBank)
    {
        SaveManager.instance.LoadData();

        if (songData.Count == songBank.Count) return;

        for (int i = 0; i < songBank.Count; i++)
        {
            Song song = new Song();
            song.title = songBank[i];
            songData.Add(song);
        }
    }


    public void SaveSongData(Song data)
    {
        for (int i = 0; i < songData.Count; i++)
        {
            if (data.title == songData[i].title)
            {
                songData.RemoveAt(i);
                songData.Add(data);
                return;
            }
        }
    }


    public Song RetrieveSongData(string songName)
    {
        for (int i = 0; i < songData.Count; i++)
        {
            if (songName == songData[i].title)
            { return songData[i]; }
        }
        return null;
    }


    public void UpdateSongData()
    {
        var data = RetrieveSongData(SongManager.songCache);
        data.playCount++;
        data.lastPlayed = System.DateTime.Now.ToString("M/d/yy");
        data.songPlayed = true;
        SaveSongData(data);
        SaveManager.instance.SaveData();
    }


    public void ClearPlayedSongs()
    { 
        foreach (Song song in songData)
        { song.songPlayed = false; }

        SaveManager.instance.SaveData();
    }


    public void ClearExcludedSongs()
    {
        foreach (Song song in songData)
        { song.excluded = false; }

        SaveManager.instance.SaveData();
    }
}
