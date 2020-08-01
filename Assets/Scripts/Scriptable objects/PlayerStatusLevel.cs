using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New Player Status Level", menuName = "Player Status Level")]
public class PlayerStatusLevel : ScriptableObject
{
    public int health;
    public int attack;
    public float speed;
}
