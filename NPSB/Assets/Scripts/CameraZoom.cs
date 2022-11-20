using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;
    float cameraDistance;
    [SerializeField] float sensitivity = 10f;
    float initialZoom;

    void Start()
    {
        initialZoom = (virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFramingTransposer).m_CameraDistance;
    }

     void Update()
    {
        if(componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;

            if(componentBase is CinemachineFramingTransposer)
            {

               float newCameraDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance - cameraDistance;

               if(newCameraDistance < 2*initialZoom && newCameraDistance > initialZoom/2)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = newCameraDistance;
                }
            }

        }
    }
}
