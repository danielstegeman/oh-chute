using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float t;
    Vector2 startPosition;
    float timeToReachTarget = 20f;
    Rigidbody2D rigidbody;
    public float movespeed = 10f;
    public Vector2 target = new Vector2(1, -80);
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var movement = new Vector2(x, Input.GetAxis("Vertical"))*movespeed*Time.deltaTime;
        if (x > 0) GetComponent<SpriteRenderer>().flipX = false;
        if (x < 0) GetComponent<SpriteRenderer>().flipX = true;
        rigidbody.AddForce(movement);
    }
    private void OnMouseUp()
    {
        
    }
}
