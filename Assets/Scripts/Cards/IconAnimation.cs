using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IconAnimation : MonoBehaviour
{
    //We use it to display the reward won and go to the card collection
    public static IconAnimation instance;
    public Image iconImage;
    Vector3 basePos;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        basePos = transform.position;
        gameObject.SetActive(false);
    }
    public Tweener StartCollectAnim(Sprite icon)
    {
        iconImage.sprite = icon;
        return transform.DOScale(6, 1.5f);
    }
    public void Restart()
    {
        transform.position = basePos;
        iconImage.sprite = null;
        gameObject.SetActive(false);
    }
}
