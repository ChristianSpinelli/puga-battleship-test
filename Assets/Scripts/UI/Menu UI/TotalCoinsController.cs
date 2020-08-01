using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinsController : MonoBehaviour
{
    [Header("References")]
    Text text;
    CurrencyData data;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentsInChildren<Text>()[1];
        data = GameDAO.LoadCurrencyData();
    }

    // Update is called once per frame
    void Update()
    {
        if (data != null)
        {
            text.text = data.totalCurrencys + "";
        }
            
    }
}
