using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Camera Cockpitcameras;
    public Camera Backcameras;
    // Start is called before the first frame update
    void Start()
    {
        Cockpitcameras.enabled = true;
        Backcameras.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cockpitcameras.enabled = !Cockpitcameras.enabled;
            Backcameras.enabled = !Backcameras.enabled;
        }
    }
}
