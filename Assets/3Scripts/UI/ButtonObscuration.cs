using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObscuration : MonoBehaviour
{
    public void Obscuration(bool state)
    {
        if(state)
            gameObject.GetComponent<Image>().color = new Color(0.9f,0.9f,0.9f,1f);
        else
            gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,1f);

    }
}
