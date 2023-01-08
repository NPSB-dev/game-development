using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrunkennessBar : MonoBehaviour
{
    private int interval = 10;
    private int currentDrunkenness;
    public DrunkennessBar drunkennessBar;

    public static bool waitTenSecBeforeDecay = false;
    public static float waitStartTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        waitTenSecBeforeDecay = false;
        currentDrunkenness = Globals.drunkenness;
        drunkennessBar.SetMaxDrunkenness(100);
    }

    // Update is called once per frame
    void Update()
    {
        currentDrunkenness = Globals.drunkenness;
        if (Time.time >= Globals.nextTimeDecayDrunkenness)
        {
            if (!waitTenSecBeforeDecay && currentDrunkenness == 100)
            {
                waitStartTime = Time.time;
                waitTenSecBeforeDecay = true;
            }
            if (waitTenSecBeforeDecay)
            {
                if (Time.time - waitStartTime >= 10)
                    waitTenSecBeforeDecay = false;
            }

            if(!waitTenSecBeforeDecay)
                if (!Globals.freezeDrunkenness)
                    DecreaseDrunkenness();
            Globals.nextTimeDecayDrunkenness += interval;
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
