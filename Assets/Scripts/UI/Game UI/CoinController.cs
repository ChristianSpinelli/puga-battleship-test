using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [Header("References")]
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentsInChildren<Text>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        //update coins colected
        text.text = CurrencyManager.instance.stageCurrencys + "";    
    }
}
