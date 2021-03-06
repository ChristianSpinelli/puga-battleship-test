﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [Header("References")]
    Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //update timer text
        if (GameManager.instance.timer > 0)
            text.text = Mathf.Floor(GameManager.instance.timer) + "";
        else
            text.text = "00";
    }
}
