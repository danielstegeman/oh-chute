using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullChord : MonoBehaviour
{
    private Character character;
    float t;
    Vector3 startPosition;
    public Vector3 target = Vector3.zero;
    public float timeToReachTarget = 0.5f;
    bool ispulling = false;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (ispulling)
        {

            t += Time.deltaTime / timeToReachTarget;
            transform.localPosition = Vector3.Lerp(startPosition, target, t);
        }
        if(ispulling&& t > timeToReachTarget)
        {
            character.PullChord();
        }
    }
    private void OnMouseUp()
    {
        ispulling = true;
    }
}
