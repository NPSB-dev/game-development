using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraFollowing;
    public GameObject cameraFixed;

    void Start()
    {
        cameraFollowing.SetActive(true);
        cameraFixed.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Toggle Zoom"))
        {
            if (cameraFollowing.activeSelf)
            {
                cameraFollowing.SetActive(false);
                cameraFixed.SetActive(true);
            }
            else
            {
                cameraFollowing.SetActive(true);
                cameraFixed.SetActive(false);
            }
        }
    }
}
