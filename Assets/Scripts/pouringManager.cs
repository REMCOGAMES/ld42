using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouringManager : MonoBehaviour {

    static bool isPouring = false;
    static int totalPours = 0;
    TargetJoint2D pouringJoint;

	// Use this for initialization
	void Start () {
        pouringJoint = GetComponent<TargetJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(isPouring == true)
        {
            Vector3 mousePos = Input.mousePosition;
            pouringJoint.anchor = mousePos ;
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
