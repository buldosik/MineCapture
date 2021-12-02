using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private GameObject _levelManager => GameObject.Find("/RockSpawner");
    private LevelCounter _levelCounter => _levelManager.GetComponent<LevelCounter>();
    private int _highestLevel => _levelCounter.LastLevelComplete;
    private int _currentLevel = 1;
    [SerializeField]
    private GameObject _prefab;
    private bool _isNextCreated = false;
    private LevelButton _nextFlag;
    private Button _thisButton => GetComponent<Button>();
    void Start()
    {
        _thisButton.onClick.AddListener(ReloadCurrentLevel);
        RealodLevels();
    }
    public void RealodLevels()
    {
        int horizontalPosition = 6 + 41 * ((_currentLevel - 1) % 4);
        int verticalPosition = -5 - 40 * ((_currentLevel - 1) / 4);
        Vector2 position = new Vector2 (horizontalPosition, verticalPosition);

        transform.GetChild(0).GetComponent<Text>().text = _currentLevel.ToString();
        GetComponent<RectTransform>().localPosition = position;
        GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        transform.name = "Level" + _currentLevel.ToString();

        if((_currentLevel - 1) % 4 == 0)
            transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 40f);


        if(_isNextCreated)
        {
            _nextFlag.RealodLevels();
            return;
        }
        

        if(_currentLevel <= _highestLevel)
        {
            _isNextCreated = true;
            GameObject _newLevel = Instantiate(_prefab);
            _newLevel.transform.SetParent(transform.parent);
            _nextFlag = _newLevel.GetComponent<LevelButton>();
            _nextFlag._currentLevel = _currentLevel + 1;
            _nextFlag._isNextCreated = false;
        }
    }
    private void ReloadCurrentLevel()
    {
        _levelCounter.SetLevel(_currentLevel);
    }
}
