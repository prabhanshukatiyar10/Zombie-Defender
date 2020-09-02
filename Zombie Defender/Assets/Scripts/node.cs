
using UnityEngine;

public class node : MonoBehaviour
{
    Color defaultcolor;
    SpriteRenderer rend;
    public bool built;
    
    bool breakdefe = false;
    public GameObject defense;
    public buildManager bm;
    

    public void readytobreak()
    {
        breakdefe = true;
    }
     void breakdef()
    {
        built = false;
        Destroy(defense);
    }
    private void Awake()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        defaultcolor = rend.color;
        
    }

    private void OnMouseDown()
    {
        

        bm.targetpos = this;
        rend.color = Color.red;
        
    }
    private void OnMouseEnter()
    {
        bm.targetpos = this;
        rend.color = Color.red;
    }
    private void OnMouseUp()
    {
        if (breakdefe)
            breakdef();
        rend.color = defaultcolor;
        bm.build();
        bm.targetpos = null;
    }

    private void OnMouseExit()
    {
        rend.color = defaultcolor;
    }

    private void Update()
    {
        if (defense == null)
            built = false;

        
    }


}
