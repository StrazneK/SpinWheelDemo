using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEditor;

[CreateAssetMenu(fileName = "Level_X", menuName = "Wheel/LevelDesignObj")]
public class LevelDesignObj : ScriptableObject
{
    public List<RewardObj> rewardObjs = new List<RewardObj>();
    public List<float> possibilities = new List<float>();


    private void OnValidate()
    {
        //We check and process so that the number of cards and the number of possibilities are equal.
        if (possibilities.Count < rewardObjs.Count)
        {
            possibilities.Add(0);
        }
        else if (possibilities.Count > rewardObjs.Count)
        {
            possibilities.RemoveAt(possibilities.Count - 1);
        }
    }
}
