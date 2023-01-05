using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelCardPool : MonoBehaviour
{
    public static LevelCardPool instance;
    Transform levelCardBase;
    List<Transform> levelCards = new List<Transform>();

    Sprite panelZoneGreen;
    Sprite panelZoneBlue;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        panelZoneGreen = SpriteFromAtlas.instance.GetSprite("ui_card_panel_zone_super");
        panelZoneBlue = SpriteFromAtlas.instance.GetSprite("ui_card_panel_zone_current"); 
        levelCardBase = transform.GetChild(0);
        levelCards.Add(levelCardBase);
        AddNewCard(60);
    }
    public void AddNewCard(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 newPos = new Vector3(levelCards[levelCards.Count - 1].localPosition.x + 120f, 0, 0);
            Transform newCard = Instantiate(levelCardBase, transform);
            newCard.localPosition = newPos;
            levelCards.Add(newCard);
            FillLevelCard(i + 1);
        }
    }
    void FillLevelCard(int number)
    {
        Sprite image = number % 5 == 0 ? panelZoneGreen : panelZoneBlue;
        levelCards[number - 1].GetComponent<LevelCard>().FillComponents(image, number);
    }
    public void NextLevel()
    {
        transform.DOLocalMoveX(transform.localPosition.x - 120, .5f);
    }
}
