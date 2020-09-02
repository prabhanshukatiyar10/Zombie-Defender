using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret1 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    public float range = 60;
    public LineRenderer laser;
    public Transform firepoint;
    public GameObject impact;
    GameObject impacteff;
    public float dps;
    public float slowrate;

    private void OnDrawGizmos()
    {
        if (buildManager.selected)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }

    private void OnDestroy()
    {
        laser.enabled = false;
        Destroy(impacteff);
    }


    void updatetarget()
    {
        
        if (target != null)
            return;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestdistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distancefromenemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distancefromenemy < shortestdistance)
            {
                shortestdistance = distancefromenemy;
                closestEnemy = enemy;
            }
        }
        if (shortestdistance < range && closestEnemy != null)
            target = closestEnemy;
        else
            target = null;
    }




    void shoot()
    {
        laser.enabled = true;
        laser.SetPosition(0, firepoint.position);
        laser.SetPosition(1, target.transform.position);
        impacteff.SetActive(true);
        impacteff.transform.position = target.transform.position;
        target.GetComponent<zombiemovement>().hitenemy(dps * Time.deltaTime);
        target.GetComponent<zombiemovement>().slowfraction = slowrate;
        target.GetComponent<SpriteRenderer>().color = Color.cyan;
    }


    void Start()
    {
        
        InvokeRepeating("updatetarget", 0f, 0.5f);
        impacteff = Instantiate(impact, transform.position, transform.rotation);
        impacteff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            impacteff.SetActive(false);
            laser.enabled = false;
            return;
        }


        Vector3 dir = target.transform.position - transform.position;
        transform.right = Vector3.Lerp(transform.right, dir, 0.1f);

        shoot();
        if (Vector3.Distance(target.transform.position, transform.position) > range)
            target = null;
    }
}
