using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy Shoots Rocket and make invisible, when it is invisble doesn take damage.
/// </summary>
public class RocketInvisibleBehavior : EnemysBehavior
{
    [SerializeField]
    float minDistanceToFireAttack, maxDistanceToFireAttack, currentDistance;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletSpeed, bulletRadiusToDamage, invisibilityDuration, invisibilityFrequency;
    float currentInvisibilityFrequencyTime, currentInvisibilityDurationTime;

    void Start()
    {
        StartStatus();
        CalculateFireRate();
        //   agent.stoppingDistance = (minDistanceToFireAttack + maxDistanceToFireAttack) / 2;
        shipTransform = GameObject.Find("AllShip").transform;


    }


    void Update()
    {
        UpdateMovimenteSpeed();
        MoveRocket();
        UpdateInvisibility();
    }


    void MoveRocket()
    {
        currentDistance = Vector2.Distance(new Vector2(shipTransform.position.x, shipTransform.position.z), new Vector2(this.transform.position.x, this.transform.position.z));
        if (currentDistance > maxDistanceToFireAttack)
        {
            agent.stoppingDistance = (minDistanceToFireAttack + maxDistanceToFireAttack) / 2;
            MoveToShip();
        }
        else if (currentDistance < minDistanceToFireAttack)
        {
            Vector3 newLocal = transform.position - shipTransform.position;
            newLocal.y = 1.25f;
            agent.stoppingDistance = 0;
            agent.SetDestination(newLocal);

        }
        else
        {
            AttackRocket();
        }
    }
   

    void ActiveInvisibility()
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;
            Color atualColor = mat.color;
            Color invisible = new Color(atualColor.r, atualColor.g, atualColor.b, 0f);
            mat.SetColor("_Color", invisible);
        }

        invisible = true;

    }

    void DesactiveInvisibility()
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;
            Color atualColor = mat.color;
            Color invisible = new Color(atualColor.r, atualColor.g, atualColor.b, 1f);
            mat.SetColor("_Color", invisible);
        }
        invisible = false;
    }
    

    void UpdateInvisibility()
    {
        if (!invisible)
        {
            
            if (currentInvisibilityFrequencyTime > invisibilityFrequency)
            {
                ActiveInvisibility();
                currentInvisibilityFrequencyTime = 0;
            }
            else
            {
                currentInvisibilityFrequencyTime += Time.deltaTime;
            }
        }
        else
        {
            if (currentInvisibilityDurationTime > invisibilityDuration)
            {
                DesactiveInvisibility();
                currentInvisibilityDurationTime = 0;
            }
            else
            {
                currentInvisibilityDurationTime += Time.deltaTime;
            }
        }
    }


    void AttackRocket()
    {
        transform.LookAt(shipTransform);

        if (currentFireDelayTime > fireDelayTime)
        {
            for (int i = 0; i < cannonsLocal.Length; i++)
            {
                GameObject currentBullet = (GameObject)Instantiate(bullet, cannonsLocal[i].position, cannonsLocal[i].rotation);
                currentBullet.GetComponent<Tower_Rocket_Bullet>().SetTowerRocketBulletStatus(status[level - 1].fireDamage, bulletRadiusToDamage, this.bulletSpeed);
            }

            currentFireDelayTime = 0;
        }
        else
        {
            currentFireDelayTime += Time.deltaTime * GameManager.Instance.gameTime;
        }
    }


    void CalculateFireRate()
    {
        fireDelayTime = 1 / status[level - 1].fireRate;
    }
}
