using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class playbutton : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public Text t1;
    static bool read = false;
    public void play()
    {
        SceneManager.LoadScene(1);

    }

    public void realinst()
    {
        if (read)
        {
            c3.SetActive(true);
            c1.SetActive(false);
        }
        else
        {

            t1.text = "Don't be oversmart." + "\n" + "Read Instructions first.";

        }

    }
    public void instructions()
    {
        
        c2.SetActive(true);
        c1.SetActive(false);
        t1.text = "";
    }

    public void thankyou()
    {
        
        c1.SetActive(true);
        c2.SetActive(false);
        read = true;
    }
}
