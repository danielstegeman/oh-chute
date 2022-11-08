using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    float t;
    Vector2 startPosition;
    float timeToReachTarget = 19f;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector2 target = new Vector2(1, -80);
    private bool isfalling = true;
    private ChuteState state = ChuteState.Falling;
    public enum ChuteState
    {
        Falling,
        Dragged,
        attached,
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (state==ChuteState.Falling)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }
    }
    void OnMouseDown()
    {
        if (state == ChuteState.Falling) state = ChuteState.Dragged;
        if(state == ChuteState.Dragged)
        {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        
    }

    void OnMouseDrag()
    {
        if (state == ChuteState.Dragged)
        {

            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
    private void OnMouseUp()
    {
        if (state == ChuteState.Dragged)
        {
            var boxCollider = gameObject.GetComponent<BoxCollider2D>();
            Collider2D[] overlap = Physics2D.OverlapAreaAll(boxCollider.bounds.min, boxCollider.bounds.max);
            RaycastHit2D hitInfo = new RaycastHit2D();


            if (overlap.Length > 1)
            {
                foreach (var collider in overlap)
                {
                    if (collider.tag == "Player")
                    {
                        transform.parent = collider.transform;
                        transform.localPosition = new Vector2(0.26f, 0.12f);
                        state = ChuteState.attached;
                        break;
                    }
                }
            }
        }
        //isfalling = true;
    }
}
