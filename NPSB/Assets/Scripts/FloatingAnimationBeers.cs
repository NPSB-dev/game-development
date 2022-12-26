using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimationBeers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 1.5f + Mathf.Sin(Time.time) * 0.5f, transform.position.z);
        Debug.Log(1 + Mathf.Sin(Time.time) * 0.5f);
    }
}
