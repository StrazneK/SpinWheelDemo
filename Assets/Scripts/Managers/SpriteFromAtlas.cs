using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteFromAtlas : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;

    public static SpriteFromAtlas instance;

    private void Awake()
    {
        instance = this;
    }

    public Sprite GetSprite(string spriteName)
    {
        return atlas.GetSprite(spriteName);
    }
}
