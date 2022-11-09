using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAttach : MonoBehaviour
{
    public GameObject target;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector3 attachOffset = Vector3.zero;
    public bool isLeft = false;
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {


        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


    }

    void OnMouseDrag()
    {


        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    private void OnMouseUp()
    {

        var boxCollider = gameObject.GetComponent<BoxCollider2D>();
        Collider2D[] overlap = Physics2D.OverlapAreaAll(boxCollider.bounds.min, boxCollider.bounds.max);
        


        if (overlap.Length > 1)
        {
            foreach (var collider in overlap)
            {
                if (collider.gameObject == target)
                {
                    transform.parent = collider.transform;
                    transform.localPosition = attachOffset;
                    if (isLeft) character.LefStrapClosed = true;
                    else character.RightStrapClosed = true;
                    break;
                }
            }
        }
    }
}
