using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    
    private Vector3 empty = Vector3.zero;

    void Update() { transform.position = Vector3.SmoothDamp(transform.position, player.TransformPoint(Vector3.back * 10f), ref empty, .3f); }
}
