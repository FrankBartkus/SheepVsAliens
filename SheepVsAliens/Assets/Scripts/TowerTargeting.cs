using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    GameObject target = null;

    [Header("Attributes")]

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Alien";

    public float turnSpeed = 10f;

    public GameObject objectToShoot;
    public bool rotate;
    public Transform firePoint;
    TowerStats stats;
    Vector3 turrentRotation;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        stats = gameObject.GetComponent<TowerStats>();
    }

    void UpdateTarget()
    {
        Character[] enemies = GameObject.FindObjectsOfType<Character>();
        float minDistance = -1f;
        float enemyDistance = Mathf.Infinity;
        GameObject furthestEnemy = null;
        foreach (Character enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.gameObject.transform.position) <= stats.range)
            {
                enemyDistance = enemy.DistanceFromStart();
                if (enemyDistance > minDistance)
                {
                    minDistance = enemyDistance;
                    furthestEnemy = enemy.gameObject;
                }
            }
        }

        if (furthestEnemy != null)
            target = furthestEnemy;
        else
            target = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Assigns closest alien in range to tower


        fireCountdown -= Time.deltaTime;
        // If there isn't a target the tower can shoot
        if (target == null) return;
        // Target lock
        direction = target.transform.position - transform.position;
        if(rotate)
        {
            turrentRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f)), Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(turrentRotation);
        }

        if (fireCountdown <= 0f)
        {
            shoot(target);
            fireCountdown = 1f / fireRate;
        }

    }

    void shoot(GameObject target)
    {
        FirePoint point = Instantiate(objectToShoot, firePoint.position, Quaternion.Euler((rotate) ? turrentRotation : new Vector3(0f, 0f, Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg))).GetComponent<FirePoint>();
        if(point != null)
            point.Fire(target);
    }
}
