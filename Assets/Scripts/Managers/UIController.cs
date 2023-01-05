using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] Transform failPanel;

    private void Awake()
    {
        instance = this;
    }
    public void OpenFailPanel()
    {
        failPanel.gameObject.SetActive(true);
    }
}
