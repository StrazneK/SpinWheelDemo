using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCardsPool : MonoBehaviour
{
    public static CollectedCardsPool instance;
    public List<CollectedCard> collectedCards = new List<CollectedCard>();
    public List<RewardObj> collectedRewards = new List<RewardObj>();
    public Transform cardBase;
    int nextCardId = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        cardBase = transform.GetChild(0);
        collectedCards.Add(cardBase.GetComponent<CollectedCard>());
        for (int i = 0; i < 50; i++)
        {
            Vector3 newPos = new Vector3(0, collectedCards[collectedCards.Count - 1].transform.localPosition.y - 80f, 0);
            Transform newCard = Instantiate(cardBase, transform);
            newCard.localPosition = newPos;
            collectedCards.Add(newCard.GetComponent<CollectedCard>());
            newCard.gameObject.SetActive(false);
        }
        cardBase.gameObject.SetActive(false);
    }
    public void AddNewCard(RewardObj rewardObj) //When we win a prize we use it to appear among the card collects
    {
        int targetCardId = GetTargetCardId(rewardObj);
        collectedCards[targetCardId].gameObject.SetActive(true);
        collectedCards[targetCardId].FillComponents(rewardObj.getIcon);
        if (nextCardId <= targetCardId)
        {
            collectedRewards.Add(rewardObj);
            nextCardId++;
        }
    }
    public int GetTargetCardId(RewardObj rewardObj) //We use it to find the id of the target card
    {
        if (collectedRewards.Contains(rewardObj))
        {
            return collectedRewards.IndexOf(rewardObj);
        }
        else
        {
            return nextCardId;
        }
    }
    public Vector3 GetTargetImagePos(RewardObj rewardObj) //Target path finding function that we will use for card animation
    {
        return collectedCards[GetTargetCardId(rewardObj)].cardImage.transform.position;
    }
}
