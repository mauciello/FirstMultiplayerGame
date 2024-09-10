using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerscript : MonoBehaviour
{
    public float timer;
    private int timerInt;
    public TMP_Text text;

    private void FixedUpdate()
    {
        if(timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            timerInt = (int)timer;
            text.text = timerInt.ToString();
        }
        else
        {
            text.text = "Comienza el juego!";
        }
    }
}
