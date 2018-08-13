using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouringManager : MonoBehaviour
{

    static public bool isPouring;
    static public int totalPours;
    TargetJoint2D pouringJoint;
    Camera mainCam;
    public LayerMask dragLayer;
    Vector3 worldPos;
    Quaternion pourRotation;
    Vector3 pourPosition;

    void Start()
    {
        totalPours = 0;
        isPouring = false;
        pourRotation = this.gameObject.transform.rotation;
        pourPosition = this.gameObject.transform.position;
        pouringJoint = GetComponent<TargetJoint2D>();
        mainCam = Camera.main;
    }
    private void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
           // var collider = Physics2D.OverlapPoint(worldPos, dragLayer);
            //if (!collider)
            //    return;

           // var body = collider.attachedRigidbody;
           // if (!body)
           //     return;
            pouringJoint = gameObject.AddComponent<TargetJoint2D>();

            pouringJoint.dampingRatio = 1.0f;
            pouringJoint.frequency = 10;

            pouringJoint.anchor = pouringJoint.transform.InverseTransformPoint(worldPos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(pouringJoint);
            pouringJoint = null;
            return;
        }

        if (totalPours == 5)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.66f, 0.66f, 0.66f);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0.66f, 0.66f, 0.66f);

        }

        if (pouringJoint)
        {
            pouringJoint.target = worldPos;
            // Debug.Log(worldPos);
            // Debug.Log(pouringJoint.target);
        }
        Debug.Log(totalPours);
    }


    private void OnMouseDown()
    {
        isPouring = true;
        totalPours += 1;


    }

    private void OnMouseUp()
    {
        gameObject.transform.rotation = pourRotation;
        gameObject.transform.position = pourPosition;
        isPouring = false;

    }
}
