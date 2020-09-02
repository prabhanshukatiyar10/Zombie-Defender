using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    public float range = 60;
    public Transform firepoint;

    public float damage = 40f;
    public float firerate = 1f;
    float firecd = 1f;
    public bullet bullet1;







    private void OnDrawGizmos()
    {
        if (buildManager.selected)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
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
           
            if(distancefromenemy < shortestdistance)
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


    void damageenemy()
    {
        if(target != null)
            target.GetComponent<zombiemovement>().hitenemy(damage);
    }
    
    void shoot()
    {
        bullet bullet2 = Instantiate(bullet1, firepoint.position, firepoint.rotation );
        bullet2.target1 = target;
        Invoke("damageenemy", 0.3f);
        
    }


    void Start()
    {
        InvokeRepeating("updatetarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            
            return;
        }
            
        Vector3 dir = target.transform.position - transform.position;
        transform.right = Vector3.Lerp(transform.right, dir, 0.1f);
        
        if (firecd <= 0f)
        {
            shoot();
            firecd = 1 / firerate;
        }
        else
            firecd -= Time.deltaTime;

        if (Vector3.Distance(target.transform.position, transform.position) > range)
            target = null;
    }
}
