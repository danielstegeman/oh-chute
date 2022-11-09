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
    public GameObject chuteAttachmentThing;
    public gamecontroller gamecontroller;
    public GameObject parachute;
    public Sprite spriteHappy;
    public bool LefStrapClosed = false;
    public bool RightStrapClosed = false;
    public bool chordPulled = false;
    public bool chuteAttached = false;
    public AudioSource wind;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (chuteAttached && !chuteAttachmentThing.activeInHierarchy && !chordPulled)
        {
            chuteAttachmentThing.SetActive(true);
            gamecontroller.UpdateHelpText("Close the leg straps and pull the chord to save yourself!\nUse the Mouse!");
        }

        var x = Input.GetAxis("Horizontal");
        var movement = new Vector2(x, 0) * movespeed * Time.deltaTime;
        if (x > 0) GetComponent<SpriteRenderer>().flipX = false;
        if (x < 0) GetComponent<SpriteRenderer>().flipX = true;
        rigidbody.AddForce(movement);
    }
    private void OnMouseUp()
    {

    }
    public void PullChord()
    {
        if (chordPulled) return;
        chordPulled = true;
        chuteAttachmentThing.SetActive(false);

        var script = parachute.GetComponent<Parachute2>();
        script.chute.SetActive(true);

        GetComponent<AudioSource>().Play();
        if (RightStrapClosed && LefStrapClosed)
        {
            wind.Stop();
            rigidbody.drag =5;
            gamecontroller.isSafe = true;
            gamecontroller.UpdateHelpText("Congratulations, you have safely deployed your parachute! \n Press space to restart");
            gamecontroller.gameover = true;
            GetComponent<SpriteRenderer>().sprite = spriteHappy;
        }
        else
        {
            var rb = parachute.GetComponent<Rigidbody2D>();
            parachute.transform.SetParent(null);
            rb.MovePosition(transform.position);
            rb.drag = 2;
            rb.bodyType = RigidbodyType2D.Dynamic;
            script.playerParent = null;
            gamecontroller.UpdateHelpText("You pulled the chord without the straps attached.\n That's not so smart.");

        }

    }
}
