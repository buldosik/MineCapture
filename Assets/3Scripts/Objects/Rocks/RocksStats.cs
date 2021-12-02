using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksStats : MonoBehaviour
{
    [SerializeField]
    private float _health;
    private float _startHealth => _health;
    [SerializeField]
    private int _coins;
    [SerializeField]
    private int _gems;
    public int GetCoins {get{return _coins; } }
    public int GetGems {get{return _gems; } }
    public void AddHealth(float Count)
    {
        _health += Count;
        if(_health <= 0)
        {
            PlayerStats.Manager.AddCoins(_coins);
            PlayerStats.Manager.AddGems(_gems);
            //Debug.Log(PlayerStats.Manager.GetCoins.ToString() + " " + PlayerStats.Manager.GetGems.ToString());
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
