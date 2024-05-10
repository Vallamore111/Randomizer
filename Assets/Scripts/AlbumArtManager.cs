using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumArtManager : MonoBehaviour
{
    public Sprite Default;
    public Sprite LightningStrikesTheCrown;
    public Sprite TalesOfSplendorAndSorrow;
    public Sprite BloodRedVictory;
    public Sprite WhereMadnessDwells;
    public Sprite KingdomTornAsunder;
    public static AlbumArtManager instance;


    private void Awake() => instance = this;
    
    public Sprite GetAlbumArt(string song)
    {
        Sprite album = Default;

        if (song == "Firestorm") album = LightningStrikesTheCrown;
        if (song == "Marching On") album = LightningStrikesTheCrown;
        if (song == "The Gorgon") album = LightningStrikesTheCrown;
        if (song == "Eternal Night") album = LightningStrikesTheCrown;
        if (song == "Fallen Glory") album = LightningStrikesTheCrown;
        if (song == "Shadow Queen") album = LightningStrikesTheCrown;
        if (song == "Kingdom Come") album = LightningStrikesTheCrown;
        if (song == "Fighting Onward") album = LightningStrikesTheCrown;

        if (song == "Bringer of Fire") album = TalesOfSplendorAndSorrow;
        if (song == "The Contract") album = TalesOfSplendorAndSorrow;
        if (song == "Sword and Shield") album = TalesOfSplendorAndSorrow;
        if (song == "Divided We Fall") album = TalesOfSplendorAndSorrow;
        if (song == "Orpheus") album = TalesOfSplendorAndSorrow;
        if (song == "Vengeance Rising") album = TalesOfSplendorAndSorrow;
        if (song == "Our Great Defender") album = TalesOfSplendorAndSorrow;

        if (song == "Gates of Evermore") album = BloodRedVictory;
        if (song == "Honor Bound") album = BloodRedVictory;
        if (song == "Seekers of the Blade") album = BloodRedVictory;
        if (song == "Blood Red Cross") album = BloodRedVictory;
        if (song == "On Ashen Wings") album = BloodRedVictory;
        if (song == "Graves of Thunder") album = BloodRedVictory;
        if (song == "Grace and Valor") album = BloodRedVictory;
        if (song == "Night Queen") album = BloodRedVictory;
        if (song == "The Serpent and the Throne") album = BloodRedVictory;
        if (song == "Horns Held High") album = BloodRedVictory;

        if (song == "Everlasting Fire") album = WhereMadnessDwells;
        if (song == "Under the Spell") album = WhereMadnessDwells;
        if (song == "Kingdom of Lies") album = WhereMadnessDwells;
        if (song == "A Funeral Within") album = WhereMadnessDwells;
        if (song == "Ready to Strike") album = WhereMadnessDwells;
        if (song == "The Phantom Flame") album = WhereMadnessDwells;
        if (song == "A Curse Upon Mankind") album = WhereMadnessDwells;
        if (song == "Where Madness Dwells") album = WhereMadnessDwells;
        if (song == "Infernal Angels") album = WhereMadnessDwells;
        if (song == "Sands of Time") album = WhereMadnessDwells;

        if (song == "Blood and Honor") album = KingdomTornAsunder;
        if (song == "Soul Survivors") album = KingdomTornAsunder;
        if (song == "Majesty of Steel") album = KingdomTornAsunder;
        if (song == "Mistress of Desire") album = KingdomTornAsunder;
        if (song == "Standing Tall") album = KingdomTornAsunder;
        if (song == "Sword of a Thousand Truths") album = KingdomTornAsunder;
        if (song == "Riding the Dragons") album = KingdomTornAsunder;
        if (song == "Shadow of the Reaper") album = KingdomTornAsunder;
        if (song == "Cold Flesh Falls") album = KingdomTornAsunder;
        if (song == "Exile of the Sun") album = KingdomTornAsunder;

        if (song == "Queen of Thorns") album = Default;
        if (song == "Wolfen") album = Default;
        if (song == "Moonchild") album = Default;
        if (song == "Shoot Out the Lights") album = Default;
        if (song == "Man on a Silver Mountain") album = Default;
        if (song == "Leather Rebel") album = Default;
        if (song == "Stay Hungry") album = Default;
        if (song == "Storm Crusher") album = Default;
        if (song == "Strange Wings") album = Default;
        if (song == "One Night in Essen") album = Default;

        return album;
    }
}
