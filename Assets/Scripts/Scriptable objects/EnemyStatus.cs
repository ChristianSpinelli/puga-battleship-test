using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New Enemy Status", menuName = "Enemy Status")]
public class EnemyStatus : ScriptableObject
{
    public int life, fireDamage, bulletsToRecharg, shieldResistence, meleeDamage;
    public float movimentSpeed, fireRate, fireRechargTime, shieldRechargTime, meleeAttackDelay, meleeAttackTime, stunTime;
}
