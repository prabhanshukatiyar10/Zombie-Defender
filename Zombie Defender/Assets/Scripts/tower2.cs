using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] target;
    public float range = 60;
    public GameObject impact;
    public float damage;
    public float firerate;
    float firecd;
    bool hasenemy;

    private void OnDrawGizmos()
    {
        if (buildManager.selected)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }




    void updatetarget()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");

        
        for(int i=0; i<target.Length; i++)
        {
            if (Vector3.Distance(target[i].transform.position, transform.position) > range)
                target[i] = null;
            
        }
        hasenemy = false;
        for(int i=0; i<target.Length; i++)
        {
            if (target[i] != null)
            {
                hasenemy = true;
                break;
            }
        }
        
       
    }


    

    void shoot()
    {
        if(hasenemy)
        {
            GameObject circle = Instantiate(impact, transform.position, transform.rotation);
            Destroy(circle, 0.5f);
        }
        foreach (GameObject enemy in target)
        {
            if (enemy != null)
            {
                enemy.GetComponent<zombiemovement>().hitenemy(damage);
                Debug.Log(enemy);
            }
            
        }
        
    }


    void Start()
    {

        InvokeRepeating("updatetarget", 0f, 0.5f);
        impact.transform.localScale = new Vector3(range, range, 1);
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (firecd <= 0)
        {
            firecd = 1 / firerate;
            shoot();
           
        }
        else
            firecd -= Time.deltaTime;
       
    }
}
