using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buildManager : MonoBehaviour
{
    public static float score = 0;
    bool radarbuilt = false;
    public static bool selected;
    public static float lives = 20;
    public static float money = 20;
    public float timeper1 = 1f;
    float x = 1;
    public GameObject[] buildings;
    public Button[] buttons;
    public float[] prices;
    public GameObject circle;
    public int objectindex = -2;
    public node targetpos;
    float time = 0;
    public Text life;
    public Text balance;
    public GameObject gameover;
    public Text points;
    public Text GOpoints;

    
    public void build()
    {
        if(objectindex == -1)
        {
            Destroy(targetpos.defense);
            objectindex = -3;
        }
            
        if (objectindex >= 0 && !targetpos.built && money >= prices[objectindex])
        {
            if (objectindex == 2 && !radarbuilt)
            {
                money -= prices[objectindex];
                targetpos.defense = Instantiate(buildings[objectindex], targetpos.transform.position, Quaternion.Euler(0, 0, 0));
                targetpos.built = true;
                objectindex = -2;
                radarbuilt = true;

            }
            else if (objectindex != 2)
            {
                money -= prices[objectindex];
                targetpos.defense = Instantiate(buildings[objectindex], targetpos.transform.position, Quaternion.Euler(0, 0, 0));
                targetpos.built = true;
                objectindex = -2;
                
            }

        }
    }

    
    public void restart()
    {
        gameover.SetActive(false);
        Debug.Log("gameover");
        money = 20;
        score = 0;
        lives = 20;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void mainmenu()
    {
        restart();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void endgame()
    {
        gameover.SetActive(true);
        GameObject.Find("WaveSpawner").SetActive(false);
        GameObject.Find("BuildManager").SetActive(false);
        GOpoints.text = points.text;
    }
    public void breakdown()
    {
        if (objectindex == -1)
            objectindex = -2;
        else
            objectindex = -1;
    }

    
    public void mgturret()
    {
        if (objectindex == 0)
            objectindex = -2;
        else
            objectindex = 0;
    }

    public void slowgun()
    {
        if (objectindex == 1)
            objectindex = -2;
        else
            objectindex = 1;
    }
    public void radar()
    {
        if (objectindex == 2)
            objectindex = -2;
        else
            objectindex = 2;
    }
    public void missile()
    {
        if (objectindex == 3)
            objectindex = -2;
        else
            objectindex = 3;
    }
    public void fire()
    {
        if (objectindex == 4)
            objectindex = -2;
        else
            objectindex = 4;
    }
    public void elec()
    {
        if (objectindex == 5)
            objectindex = -2;
        else
            objectindex = 5;
    }
    public void rad()
    {
        if (objectindex == 6)
            objectindex = -2;
        else
            objectindex = 6;
    }


    private void Update()
    {
        time += Time.deltaTime;
        if(time >= timeper1)
        {
            
            time = 0;
            money += 1;
        }
        balance.text = "$" + money.ToString();
        points.text = "Score:" + "\n" + score.ToString();
        life.text = "Lives:" + "\n" + lives.ToString();

        if(lives <= 0)
        {
            endgame();
        }
        
        for(int i=0; i<buttons.Length; i++)
        {
            if (i - 1 == objectindex)
                buttons[i].image.color = Color.black;
            else
                buttons[i].image.color = Color.white;
        }
        GameObject rad = GameObject.FindGameObjectWithTag("radar");
        if (rad == null)
            radarbuilt = false;

        if (objectindex >= -1)
            selected = true;
        else
            selected = false;

        

    }

}
