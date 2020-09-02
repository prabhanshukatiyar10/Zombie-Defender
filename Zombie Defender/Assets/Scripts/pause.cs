using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool paused = false;
    public GameObject pausemenu;
    public void pausegame()
    {
        Time.timeScale = 0;
        pausemenu.SetActive(true);
        paused = true;
    }

    public void resume()
    {
        Time.timeScale = 1;
        pausemenu.SetActive(false);
        paused = false;
    }

    public void speedup()
    {
        Time.timeScale = (((int)Time.timeScale) * 2) % 3;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
                pausegame();
            else
                resume();
        }
    }
}
