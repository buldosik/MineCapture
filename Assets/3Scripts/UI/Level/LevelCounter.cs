using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    private SpawnRocks _spawnManager => GetComponent<SpawnRocks>();
    [SerializeField]
    private CurrentLevelDisplay _levelDisplayer;
    public int LastLevelComplete = 0;
    public int CurrentLevel = 1;
    public void LevelComplete()
    {
        LastLevelComplete++;
        SetLevel(LastLevelComplete);
    }
    public void SetLevel(int temp)
    {
        CurrentLevel = temp;
        _levelDisplayer.SetLevel(CurrentLevel);
        _spawnManager.ReGenerate();
    }
}
