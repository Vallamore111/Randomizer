using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Song
{
    public string title;
    public int playCount = 0;
    public string lastPlayed;
    public bool songPlayed;
    public bool excluded;
}
