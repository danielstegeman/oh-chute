using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget = 20f;
    GameObject player;
    public float yOffset = -5f;
    public bool isSafe = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = new Vector3(transform.position.x,player.transform.position.y+yOffset,transform.position.z);

    }
}
