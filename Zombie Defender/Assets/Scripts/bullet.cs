using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target1;
    public float speed;
    
    public GameObject destroyanim;
   
    private void hit()
    {
        GameObject danim =  Instantiate(destroyanim, transform.position, transform.rotation);
        Destroy(danim, 0.2f);
        
        Destroy(gameObject);
        
        return;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target1 == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate((target1.transform.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
        float distance = Vector3.Magnitude(transform.position - target1.transform.position);
        if(distance <= 4f)
        {
            hit();
            return;
        }
    }
}
