/// <summary>
/// Cell manager.
/// Coded by Puneet Rawat
/// </summary>
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cellManager : MonoBehaviour
{
    bool alive;

    public List<cellManager> neighbors;
    RawImage img;


    // Start is called before the first frame update
    void Start()
    {
        //Init
        img = this.GetComponent<RawImage>();
    }

    public void willBeAlive(float value)
    {
        alive = Random.Range(0.0f, 1.0f) <= value ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
            img.color = Color.black;
        else
            img.color = Color.white;
    }

    public void tick()
    {
        int count = 0;
        for(int i = 0; i < neighbors.Count; i++)
        {
            if(neighbors[i].alive)
                count++;
        }
        if (count == 3)
            alive = true;
        else if (count < 2 || count > 3)
            alive = false;
    }
}
