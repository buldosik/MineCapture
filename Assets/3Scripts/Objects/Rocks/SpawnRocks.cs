using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    [SerializeField]
    private List <GameObject> _RocksPrefabs;
    [SerializeField]
    private List <GameObject> _CrystalPrefabs;
    [SerializeField]
    private GameObject _Prefab;
    [Range(0, 100)] [SerializeField]
    private float _ChanceToSpawnRock;
    [SerializeField]
    private float _MaxPosX;
    private float _MinPosX;

    [SerializeField]
    private float _MaxPosZ;
    private float _MinPosZ;

    [SerializeField]
    private float _DistanceX;
    [SerializeField]
    private float _DistanceZ;
    
    [SerializeField]
    private float _MaxRotationX;
    [SerializeField]
    private float _MaxRotationY;
    [SerializeField]
    private float _MaxRotationZ;
    [HideInInspector]
    public int _generationCount;
    private GameObject _RocksCounter;
    private void Start()
    {
        _MinPosX = 0-_MaxPosX;
        _MinPosZ = 0-_MaxPosZ;  
        if(CheckParent())
            return;
        Generation();
    }
    private void Update()
    {
        if(CheckParent())
            return;
        if(transform.GetChild(1).childCount == 0)
            Generation();
    }
    private void Generation()
    {
        _generationCount++; 
        CheckParent();
        for(float i = _MinPosX; i < _MaxPosX; i += _DistanceX)
        {
            for(float j = _MinPosZ; j < _MaxPosZ; j += _DistanceZ)
            {
                GameObject newRock;
                int temp = Random.Range(0,100000) % 100;
                if(temp <= _ChanceToSpawnRock)
                {
                    newRock = Instantiate(_RocksPrefabs[Random.Range(0,_RocksPrefabs.Count)]);
                }
                else
                {
                    newRock = Instantiate(_CrystalPrefabs[Random.Range(0,_CrystalPrefabs.Count)]);
                }
                newRock.transform.SetParent(transform.GetChild(1).transform);
                newRock.transform.position = new Vector3(i, 0, j);
                newRock.transform.rotation = Quaternion.Euler(Random.Range(-_MaxRotationX,_MaxRotationX),
                                                              Random.Range(-_MaxRotationY,_MaxRotationY),
                                                              Random.Range(-_MaxRotationZ,_MaxRotationZ));
            }
        }
    }
    private bool CheckParent()
    {
        if(transform.childCount < 2)
        {
            _RocksCounter = Instantiate(_Prefab);
            _RocksCounter.transform.SetParent(transform);
            return true;
        }
        return false;
    }
    public void ReGenerate()
    {
        Destroy(_RocksCounter);
        if(transform.GetChild(1).childCount == 0)
            Generation();   
    }
}
