using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrunkennessBar : MonoBehaviour
{
    private int interval = 10;
    private float nextTime = 10;
    private int currentDrunkenness;
    public DrunkennessBar drunkennessBar;

    // Start is called before the first frame update
    void Start()
    {
        currentDrunkenness = Globals.drunkenness;
        drunkennessBar.SetMaxDrunkenness(100);
    }

    // Update is called once per frame
    void Update()
    {
        currentDrunkenness = Globals.drunkenness;
        if (Time.time >= nextTime)
        {
            DecreaseDrunkenness();
            nextTime += interval;
        }
    }

    public void DecreaseDrunkenness()
    {
        if (currentDrunkenness - 1 >= 0)
        {
            currentDrunkenness = currentDrunkenness - 1;
        }
        else
        {
            currentDrunkenness = 0;
        }
        drunkennessBar.SetDrunkenness(currentDrunkenness);
    }

}
