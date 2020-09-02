using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 40f;
    float horizontalmove, verticalmove = 0f;
    public Joystick jstk;

    private void Start()
    {
        Physics.gravity = new Vector3(0f, -1000f, 0f);
    }
    void Update()
    {
        if (Mathf.Abs(jstk.Horizontal) > 0.1f)
            horizontalmove = (jstk.Horizontal);
        else
            horizontalmove = 0;

        if (Mathf.Abs(jstk.Vertical) > 0.1f)
            verticalmove = (jstk.Vertical);
        else
            verticalmove = 0f;
        Vector3 dir = new Vector3(horizontalmove, 0f, verticalmove);

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}
