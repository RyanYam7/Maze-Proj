using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeChangeMap : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = Vector3.zero;
 		Vector3 direction = Vector3.forward;
 		RaycastHit hit;
 		if(Physics.Raycast(start, direction, out hit))
 		{
    		 hit.collider.gameObject.layer = 10;
 		}
    }
}
