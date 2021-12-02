using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats
{
    public static PlayerStats Manager = new PlayerStats();
    [SerializeField]
    private int coins;
    [SerializeField]
    private int gems;

    public int GetCoins {get{return coins;} }
    public void AddCoins(int temp) => coins += temp;
    public int GetGems {get{return gems;} }
    public void AddGems(int temp) => gems += temp;
}
