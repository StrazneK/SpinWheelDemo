using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;
    LevelManager levelManager;
    WheelDesign wheelDesign;
    LevelCardPool levelCardPool;
    Spin spin;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameState = GameState.Resume;
        levelManager = LevelManager.instance;
        wheelDesign = WheelDesign.instance;
        levelCardPool = LevelCardPool.instance;
        spin = Spin.instance;
    }
    public void NextLevel()
    {
        levelManager.NextLevel();
        wheelDesign.SetLevelObjs();
        levelCardPool.NextLevel();
        spin.NextLevel();
    }
    public void RestartGame()
    {
        levelManager.RestartGame();
    }
    public enum GameState //We use it to set the times when we want and don't want to receive input from the user.
    { 
        Pause,
        Resume
    }
}
