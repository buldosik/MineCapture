using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelDisplay : MonoBehaviour
{
    public void SetLevel(int level)
    {
        GetComponent<Text>().text = "Level " + level.ToString();
    }
}
