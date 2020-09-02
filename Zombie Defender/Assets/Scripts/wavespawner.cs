
using UnityEngine;
using System.Collections;

public class wavespawner : MonoBehaviour
{
    public GameObject[] zombies = new GameObject[8];
    GameObject enem;
    int level = 0;
    float time = 0;
    public buildManager bm;
    public Transform spawnpoint;

    void make(int i, int difflvl)
    {
        enem = Instantiate(zombies[i], transform.position, transform.rotation);
        enem.GetComponent<zombiemovement>().health *= Mathf.Pow(1.6f, difflvl);
        enem.GetComponent<zombiemovement>().speed *= Mathf.Pow(1.1f, difflvl);
        
    }

    void increasediff()
    {
        level++;
        bm.timeper1 += 1.5f;
    }
    IEnumerator startlevel(int lvl)
    {
        
        switch (lvl)
        {
            case 1:
                yield return new WaitForSeconds(3);
                make(0, 0);
                break;

            case 2:
                for(int i=0; i<3; i++)
                {
                    make(0, 0);
                    yield return new WaitForSeconds(1);
                }
                break;

            case 3: 
                for(int i=0; i<6; i++)
                {
                    make(Random.Range(0, 2), 0);
                    yield return new WaitForSeconds(1.2f);
                }
                break;

            case 4:
                for(int i=0; i<2; i++)
                {
                    make(2, 0);
                    yield return new WaitForSeconds(2);
                }
                break;

            case 5:
                make(3, 0);
                break;

            case 6:
                for(int i=0; i<3; i++)
                {
                    make(4, 0);
                    yield return new WaitForSeconds(1.5f);
                }
                break;



            default:
                if(lvl%7 == 0)
                {
                    increasediff();
                    for(int i=0; i<lvl/14 + 1; i++)
                    {
                        make(5, level);
                        yield return new WaitForSeconds(3f);
                    }
                }
                else
                {
                    for(int i=0; i<Random.Range(Mathf.Min(lvl, 15), Mathf.Min(lvl+5, 20)); i++)
                    {
                        make(Random.Range(0, 5), level);
                        yield return new WaitForSeconds(1f);
                    }
                }
                break;
                
        }
        
    }

    IEnumerator lvlmanager()
    {
        int i = 1;
        while (true)
        {
            StartCoroutine(startlevel(i));
            yield return new WaitForSeconds(Mathf.Min(50f, i*i + 10));
            i++;
        }
    }
    private void Awake()
    {
        
       
    }

    private void Start()
    {
        StartCoroutine(lvlmanager());

        
    }

    private void Update()
    {
      
    }
}
