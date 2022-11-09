using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute2 : MonoBehaviour
{
    bool isAttached = false;
    Rigidbody2D rigidbody;
    public GameObject playerParent = null;
    public Character Character;
    public GameObject chute;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        float x = Random.Range(-10,10);
        transform.position  =new Vector3(x,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerParent != null)
        {
            bool isFlipped = playerParent.GetComponent<SpriteRenderer>().flipX;
            GetComponent<SpriteRenderer>().flipX = isFlipped;

            if (isFlipped) transform.localPosition = new Vector3(-0.26f, 0.12f, transform.position.z);
            else transform.localPosition = new Vector3(0.26f, 0.12f, transform.position.z);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (!isAttached && collision.tag == "Player")
            {
                isAttached = true;
                var player = collision.gameObject;
                rigidbody.bodyType = RigidbodyType2D.Kinematic;
                transform.parent = player.transform;
                transform.localPosition = new Vector3(0.26f, 0.12f, transform.position.z);
                playerParent = player;
                Character.chuteAttached = true;
            }
        }
    }
}
