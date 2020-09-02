using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower1 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target = null;
    public float range = 60;
    public LineRenderer laser;
    public Transform firepoint;
    public GameObject impact;
    GameObject impacteff;
    public float firerate;
    float firecd;
    
    public float damage;
    public SpriteRenderer rnd;

    private void OnDrawGizmos()
    {
        if (buildManager.selected)
        {
            Gizmos.color = Color.red;
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


    void disablelaser()
    {
        laser.enabled = false;
        impacteff.SetActive(false);
        rnd.color = Color.white;
    }

    void shoot()
    {
        laser.enabled = true;
        
        laser.SetPosition(0, firepoint.position);
        laser.SetPosition(1, .3754068f * target.transform.position + (1f- .375406800f)*transform.position);
        laser.SetPosition(2, .525244f * target.transform.position + (1f - .525244f) * transform.position);
        laser.SetPosition(3, 0.7f * target.transform.position + (0.3f) * transform.position);
        
        laser.SetPosition(4, target.transform.position);

        impacteff.SetActive(true);
        
        target.GetComponent<zombiemovement>().hitenemy(damage);
        rnd.color = Color.yellow;
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

        if (firecd <= 0)
        {
            firecd = 1 / firerate;
            shoot();
            Invoke("disablelaser", 0.3f);
            Debug.Log("hello");
        }
        else
            firecd -= Time.deltaTime;

        if (Vector3.Distance(target.transform.position, transform.position) > range)
            target = null;

        if (target != null)
            impacteff.transform.position = target.transform.position;
        else
            impacteff.SetActive(false);
    }

    

}
