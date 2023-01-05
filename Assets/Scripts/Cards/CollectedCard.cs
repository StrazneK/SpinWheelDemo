using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectedCard : MonoBehaviour
{
    public Image cardImage;
    public TextMeshProUGUI txtCount;
    int count = 1;
    public void FillComponents(Sprite _cardImage) //We use it for correct display of cards 
    {
        cardImage.sprite = _cardImage;
        txtCount.text = count.ToString();
        count++;
    }
}
