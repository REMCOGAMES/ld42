using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouringManager : MonoBehaviour {

    public bool isPouring = false;
    static int totalPours = 0;
    TargetJoint2D pouringJoint;
    Camera mainCam;
	// Use this for initialization
	void Start () {
        //pouringJoint = GetComponent<TargetJoint2D>();
        mainCam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
      

	}
    private void FixedUpdate()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            var collider = GetComponent<Collider2D>();

            var body = collider.attachedRigidbody;

            pouringJoint = body.gameObject.AddComponent<TargetJoint2D>();
            pouringJoint.dampingRatio = 1.0f;
            pouringJoint.frequency = 1;

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
    }
    private void OnMouseDown()
    {
        isPouring = true;


    }

    private void OnMouseUp()
    {
        isPouring = false;
    }
}
