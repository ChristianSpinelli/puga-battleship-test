using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
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
    }

    private void Update()
    {
        if (GameManager.instance.endGame)
            OnFinish();
    }

    public void AddCurrency(int valueToAdd)
    {
        stageCurrencys += valueToAdd;
    }

   private void OnFinish()
    {
        totalCurrencys += stageCurrencys;
        stageCurrencys = 0;
    }
}
