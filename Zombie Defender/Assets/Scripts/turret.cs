using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target = null;
    public float range = 60;


    public float dps;

    public GameObject anim;




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
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



    
    void shootMG()
    {
        anim.SetActive(true);
        target.GetComponent<zombiemovement>().hitenemy(dps * Time.deltaTime);
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
            anim.SetActive(false);
            return;
        }
            
        Vector3 dir = target.transform.position - transform.position;
        transform.right = Vector3.Lerp(transform.right, dir, 0.01f);

        shootMG();
        if (Vector3.Distance(target.transform.position, transform.position) > range)
            target = null;
    }
}
