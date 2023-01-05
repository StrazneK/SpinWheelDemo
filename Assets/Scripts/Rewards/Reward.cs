using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    [SerializeField] Transform iconImage;
    public void FillRewardComponents(RewardObj rewardObj)
    {
        iconImage.GetComponent<Image>().sprite = rewardObj.getIcon;
    }
}
