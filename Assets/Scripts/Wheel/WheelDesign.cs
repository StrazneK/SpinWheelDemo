using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelDesign : MonoBehaviour
{
    public static WheelDesign instance;

    public Image spinBase;
    public Image spinIndicator;
    public Transform rewardArea;

    LevelManager levelManager;
    SpriteFromAtlas spriteFromAtlas;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        levelManager = LevelManager.instance;
        spriteFromAtlas = SpriteFromAtlas.instance;
        SetLevelObjs();
    }
    public void SetLevelObjs()
    {
        LevelDesignObj levelDesignObj = levelManager.GetLevelDesignObj();
        for (int i = 0; i < rewardArea.childCount; i++)
        {
            rewardArea.GetChild(i).GetComponent<Reward>().
                FillRewardComponents(levelDesignObj.rewardObjs[i]);
        }
        SetSpecialLevel();
        GameManager.instance.gameState = GameManager.GameState.Resume;
    }
    public void SetSpecialLevel()
    {
        if (levelManager.level % 30 == 0)
        {
            spinIndicator.sprite = spriteFromAtlas.GetSprite("ui_spin_golden_indicator");
            spinBase.sprite = spriteFromAtlas.GetSprite("ui_spin_golden_base");
        }
        else if (levelManager.level % 5 == 0)
        {
            spinIndicator.sprite = spriteFromAtlas.GetSprite("ui_spin_silver_indicator");
            spinBase.sprite = spriteFromAtlas.GetSprite("ui_spin_silver_base");
        }
        else
        {
            spinIndicator.sprite = spriteFromAtlas.GetSprite("ui_spin_bronze_indicator");
            spinBase.sprite = spriteFromAtlas.GetSprite("ui_spin_bronze_base");
        }
    }
}
