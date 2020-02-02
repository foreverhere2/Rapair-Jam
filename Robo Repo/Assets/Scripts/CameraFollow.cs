using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    public Movement player;

    [Range(2, 10)] public int weight;
    private Vector3 empty = Vector3.zero;

    private void Start()
    {
        cam = cam == null ? GetComponent<Camera>() : cam;
        player = player ?? GameObject.Find("Player").GetComponent<Movement>();
        weight = weight == 0 ? 4 : weight;
    }
    void Update()
    {
        Vector3 target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + (player.gameObject.transform.TransformPoint(Vector3.back * 10f + Vector3.up * 1.5f) * (weight - 1))) / weight;
        target = new Vector3(target.x, target.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref empty, .3f);
        if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)) > 1.9f
            && cam.orthographicSize < 4f)
        {
            cam.orthographicSize *= 1.001f;
        }
        else if(!player.isGrounded && cam.orthographicSize < 5f)
        {
            cam.orthographicSize *= 1.001f;
        }
        else if(cam.orthographicSize > 3f)
        {
            cam.orthographicSize /= 1.0025f;
        }
    }
}
