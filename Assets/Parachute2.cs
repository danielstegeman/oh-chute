using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute2 : MonoBehaviour
{
    bool isAttached = false;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
     void OnTriggerStay2D(Collider2D collision)
    {
        if (!isAttached && Input.GetKeyUp(KeyCode.Space) &&collision.tag =="Player")
        {
            isAttached = true;
            var player = collision.gameObject;
            rigidbody.isKinematic = true;
            transform.parent = player.transform;
            transform.localPosition = new Vector2(0.26f, 0.12f);
        }
    }
}
