using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    Text text;
    GameObject player;
    ShipController ship;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentsInChildren<Text>()[1];
        player = GameObject.FindGameObjectWithTag("Ship");
        ship = player.GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        //update text life
        text.text = ship.allStatus[ship.healthLevel - 1].health+"";
    }
}
