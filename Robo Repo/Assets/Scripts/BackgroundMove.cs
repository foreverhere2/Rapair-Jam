using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public Transform player;
    [Range(0f, 1f)] public float moveCoefficient;

    void Start()
    {
        player = player == null ? GameObject.Find("Player").transform : player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position * moveCoefficient;
    }
}
