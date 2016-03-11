using UnityEngine;
using System.Collections;

public class CharacterCustomozator : MonoBehaviour {
    public SpriteRenderer headSprite;
    public Color32[] skinColors;
    int skinColorCounter = 0;

    public SpriteRenderer torseSprite;
    public Color32[] torseColors;
    int torseColorCounter = 0;

    public SpriteRenderer legSprite;
    public Color32[] legColors;
    int legColorCounter = 0;

    public void ChangeSkinColor()
    { 
        skinColorCounter++;
        if(skinColorCounter>=skinColors.Length) skinColorCounter = 0;
        headSprite.color = skinColors[skinColorCounter];
    }

    public void ChangeTorseColor()
    {
        torseColorCounter++;
        if (torseColorCounter >= torseColors.Length) torseColorCounter = 0;
        torseSprite.color = torseColors[torseColorCounter];
    }

    public void ChangeLegColor()
    {
        legColorCounter++;
        if (legColorCounter >= legColors.Length) legColorCounter = 0;
        legSprite.color = legColors[legColorCounter];
    }
}
