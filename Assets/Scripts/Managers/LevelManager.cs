using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int level = 1;
    public List<LevelDesignObj> levels = new List<LevelDesignObj>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ResetLevel();
    }
    public void NextLevel()
    {
        level++;
    }
    public void ResetLevel()
    {
        level = 1;
    }
    public LevelDesignObj GetLevelDesignObj()
    {
        return levels[level - 1];
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
