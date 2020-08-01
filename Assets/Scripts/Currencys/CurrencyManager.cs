using UnityEngine;
using System;

public class CurrencyManager : MonoBehaviour
{
    [Header("Singleton")]
    public static CurrencyManager instance;
    public static CurrencyManager Instance { get { return instance; } }


    [Header("References")]
    public GameObject coinMesh;

    [Header("Settings")]
    public int maxCountForCurrencys;

    [Header("Behaviour")]
    [HideInInspector] public int totalCurrencys;
    [HideInInspector] public int stageCurrencys;


    void Awake()
    {
        instance = this;
        CurrencyData data = GameDAO.LoadCurrencyData();
        if (data != null)
        {
            totalCurrencys = data.totalCurrencys;
        }
               
        
    }


    public void AddCurrency(int valueToAdd)
    {
        stageCurrencys += valueToAdd;
    }

  public void OnFinish()
    {
        totalCurrencys += stageCurrencys;
        stageCurrencys = 0;
        CurrencyData data = new CurrencyData();
        data.totalCurrencys = totalCurrencys;
        GameDAO.SaveCurrencyData(data);
    }
}

[Serializable]
public class CurrencyData
{
    public int totalCurrencys;
}
