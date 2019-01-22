using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    // Use this for initialization
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                Debug.Log("done");
            }

        }
    }
}
