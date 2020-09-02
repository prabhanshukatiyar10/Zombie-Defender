using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*increase money pe unit time
 * change layer of effects and lasers
 */
public class zombiemovement : MonoBehaviour
{
    Vector3 dir;
    int waypointindex = 14;
    public float speed;
    public float slowfraction = 1;
    public Animator anim;
    public bool monster;
    public GameObject blob;
    public bool ghost = false;
    public float index;
    public float killmoney;
    public float killscore;
    private SpriteRenderer rnd;
    private Transform target;
    public float health = 100;
    public Canvas hbar;
    float time = 0;
    float healthi;
    public GameObject die_effect;

    void backtonormal()
    {
        rnd.color = Color.white;
        slowfraction = 1;
    }

    

    public void hitenemy(float damage)
    {
        health -= damage;
        rnd.color = Color.red;
        
        Invoke("backtonormal", 0.2f);
        if (health <= 0)
        {
            GameObject die = Instantiate(die_effect, transform.position, transform.rotation);
            buildManager.score += killscore;
            buildManager.money += killmoney;
            Destroy(gameObject);
            Destroy(die, 0.5f);
        }
        hbar.transform.localScale = new Vector3( health / healthi, 1, 1);
    }

    void reducelife()
    {
        buildManager.lives -= 1;
    }
    void Start()
    {
        healthi = health;
        time += Time.deltaTime;
        rnd = gameObject.GetComponent<SpriteRenderer>();
        target = waypoints.points[waypointindex];
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!monster)
        {
            dir = (target.position - transform.position);
            transform.Translate(dir.normalized * speed * slowfraction * Time.deltaTime, Space.World);

            if (Vector3.Distance(target.position, transform.position) <= 3f)
            {
                waypointindex--;
                if (waypointindex == -1)
                {

                    Destroy(gameObject);
                    reducelife();
                    return;
                }
                target = waypoints.points[waypointindex];
            }
            if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
            {
                if (dir.y > 0)
                    anim.SetFloat("vertical", 1f);
                else
                    anim.SetFloat("vertical", -1f);

                anim.SetFloat("horizontal", 0f);
            }
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                if (dir.x > 0)
                {
                    anim.SetFloat("horizontal", 1f);
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }

                else
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    anim.SetFloat("horizontal", -1f);
                }
                anim.SetFloat("vertical", 0f);
            }


        }
        else if(monster)
        {
            dir = (target.position - transform.position);
            transform.Translate(dir.normalized * speed * slowfraction * Time.deltaTime, Space.World);

            if (Vector3.Distance(target.position, transform.position) <= 16f)
            {
                waypointindex-=Random.Range(3, 5);

                if (waypointindex <= 0)
                {
                    waypointindex = Random.Range(14, 16);
                    return;
                }
                target = waypoints.points[waypointindex];
            }
            if(time >= 8)
            {
                Instantiate(blob, transform.position, transform.rotation);

                time = 0;
            }
        }

        if(ghost)
        {
            if (gameObject.tag == "hidden")
            {
                Color temp = rnd.color;
                temp.a = 0.2f;
                rnd.color = temp;
            }
            else
            {
                rnd.color = Color.white;
                
            }
        }
                
        
    }
}
