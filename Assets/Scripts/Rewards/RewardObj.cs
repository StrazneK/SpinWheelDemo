using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Reward_Obj_X", menuName = "Wheel/RewardObj")]
public class RewardObj : ScriptableObject
{
    public Sprite icon;
    public bool isBomb = false;
    //We get images from editors for easy editing. But when calling the entered image
    //We call it from the Sprite Atlas because we are performance-oriented.
    public Sprite getIcon
    {
        get
        {
            return SpriteFromAtlas.instance.GetSprite(icon.name);
        }
        set
        {
            icon = value;
        }
    }
}
