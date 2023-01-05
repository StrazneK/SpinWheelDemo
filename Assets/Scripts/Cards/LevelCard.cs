using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI txtCount;
    public void FillComponents(Sprite _image,int _count)
    {
        image.sprite = _image;
        txtCount.text = _count.ToString();
    }
}
