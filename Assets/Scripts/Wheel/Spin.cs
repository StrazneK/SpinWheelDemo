using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spin : MonoBehaviour
{
    public static Spin instance;

    LevelDesignObj levelDesignObj;
    Transform spinBase;
    float[] possibilities;
    int selectedId = 0;
    IconAnimation iconAnimation;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        iconAnimation = IconAnimation.instance;
        levelDesignObj = LevelManager.instance.GetLevelDesignObj();
        spinBase = GetComponent<WheelDesign>().spinBase.transform;
    }

    public void StartSpin() //Wheel rotation and selected card animations
    {
        Vector3 targetAngle = new Vector3(0, 0, CalcAngle());
        RewardObj selectedReward = levelDesignObj.rewardObjs[selectedId];
        spinBase.DORotate(targetAngle, 2, RotateMode.FastBeyond360).OnComplete(() =>
        {
            iconAnimation.gameObject.SetActive(true);

            iconAnimation.StartCollectAnim(selectedReward.getIcon).OnComplete(() =>
            {
                if (selectedReward.isBomb)
                {
                    UIController.instance.OpenFailPanel();
                    return;
                }
                iconAnimation.transform.DOScale(1, 1);
                iconAnimation.transform.DOMove(CollectedCardsPool.instance.GetTargetImagePos(selectedReward), 1).OnComplete(() =>
                {
                    iconAnimation.Restart();
                    CollectedCardsPool.instance.AddNewCard(selectedReward);
                    GameManager.instance.NextLevel();
                });
            });
        });

    }
    void CalcPossibility() //We calculate which prize will come out according to the chance rates entered
    {
        float totalPoss = 0;
        possibilities = new float[levelDesignObj.possibilities.Count];

        for (int i = 0; i < levelDesignObj.possibilities.Count; i++)
        {
            possibilities[i] = levelDesignObj.possibilities[i];
            totalPoss += possibilities[i];
        }

        float resultCount = Random.Range(1, totalPoss);
        float currentTotal = 0;
        float selectedPoss;
        for (int i = 0; i < possibilities.Length; i++)
        {
            selectedPoss = possibilities[i];
            currentTotal += selectedPoss;
            if (selectedPoss != 0 && resultCount <= currentTotal)
            {
                selectedId = i;
                return;
            }
        }
    }

    int CalcAngle() //We calculate the angle that must be rotated in order to receive the chosen prize
    {
        CalcPossibility();
        return 360 + (selectedId * 45);
    }

    public void NextLevel()
    {
        levelDesignObj = LevelManager.instance.GetLevelDesignObj();
    }
   
}
