using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public GameObject resultPanel;
    Text resultText;
    


    // Start is called before the first frame update
    void Start()
    {
        resultText = resultPanel.GetComponentInChildren<Text>();
        resultPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //verify if the game finish
        if (GameManager.instance.endGame)
        {
            resultPanel.SetActive(true);
            
            if (GameManager.instance.winGame)
                resultText.text = "You Win";
            else
                resultText.text = "You Lose";
            
        }
    }

    public void OnRestart()
    {
        resultPanel.SetActive(false);
    }
}
