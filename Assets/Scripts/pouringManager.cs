using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouringManager : MonoBehaviour
{

    static public bool isPouring = false;
    static public int totalPours = 0;
    TargetJoint2D pouringJoint;
    Camera mainCam;
    Vector3 worldPos;
    Quaternion pourRotation;

    // Use this for initialization
    void Start()
    {
        pourRotation = this.gameObject.transform.rotation;
        pouringJoint = GetComponent<TargetJoint2D>();
        mainCam = Camera.main;
    }
    private void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

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


        if (pouringJoint)
        {
            pouringJoint.target = worldPos;
            Debug.Log(worldPos);
            Debug.Log(pouringJoint.target);
        }

        if (gameObject.transform.rotation.eulerAngles.z > 90)
            transform.rotation.eulerAngles.Set(0, 0, 90);

        //if total pours is greater than a set number we want to make it non-interactable
        if (totalPours > 4)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    private void OnMouseDown()
    {
        isPouring = true;


    }

    private void OnMouseUp()
    {
        gameObject.transform.rotation = pourRotation;
        totalPours += 1;
        isPouring = false;

    }
}
