﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    public Movement player;
    
    private Vector3 empty = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.gameObject.transform.TransformPoint(Vector3.back * 10f), ref empty, .3f);
        if(!player.isGrounded && cam.orthographicSize < 6f)
        {
            cam.orthographicSize *= 1.0005f;
        }
        else if(cam.orthographicSize > 5f)
        {
            cam.orthographicSize /= 1.001f;
        }
    }
}
