using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radar : MonoBehaviour
{
    GameObject[] kings;
    GameObject[] spottedkings;
    public float range;
    public Animator anim;


    void getkings()
    {
        

        spottedkings = GameObject.FindGameObjectsWithTag("Enemy");
        if (spottedkings.Length == 0)
            anim.enabled = false;
        foreach(GameObject sking in spottedkings)
        {
            if (Vector3.Distance(sking.transform.position, transform.position) > range && sking.GetComponent<zombiemovement>().ghost)
            {
                sking.tag = "hidden";
                anim.enabled = false;
            }
        }

        kings = GameObject.FindGameObjectsWithTag("hidden");

        foreach (GameObject king in kings)
        {
            if (Vector3.Distance(king.transform.position, transform.position) < range)
            {
                anim.enabled = true;
                king.tag = "Enemy";
            }
            
        }
    }
    void Start()
    {
        InvokeRepeating("getkings", 0.5f, 0.5f);
    }


    private void OnDrawGizmos()
    {
        if (buildManager.selected)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, range);
            
        }
    }
}
