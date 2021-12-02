using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private GameObject _parent => transform.parent.gameObject;
    private LevelCounter _levelManager => _parent.GetComponent<LevelCounter>();
    private SpawnRocks _generationManager => _parent.GetComponent<SpawnRocks>();
    private void OnCollisionEnter(Collision other)
    {
        if(_generationManager._generationCount > 1 && _levelManager.CurrentLevel - 1 == _levelManager.LastLevelComplete)
        {
            _levelManager.LevelComplete();
            _levelManager.SetLevel(_levelManager.LastLevelComplete + 1);
            _generationManager._generationCount = 0;
            _generationManager.ReGenerate();
        }
        if(_levelManager.LastLevelComplete > _levelManager.CurrentLevel - 1)
        {
            _levelManager.SetLevel(_levelManager.CurrentLevel + 1);
            _generationManager.ReGenerate();
        }
    }
}
