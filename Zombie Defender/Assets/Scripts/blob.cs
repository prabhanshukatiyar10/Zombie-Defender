using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blob : MonoBehaviour
{
    GameObject[] defences;
    GameObject target;
    void Start()
    {
        defences = GameObject.FindGameObjectsWithTag("defence");
        if(defences.Length == 0)
        {
            Destroy(gameObject);
            return;
        }
        target = defences[Random.Range(0, defences.Length)];
        Destroy(target, 1);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject != null)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.1f);
    }
}
