using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float speed = 0.005f;

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            move.z = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x = 1f;
        }

        move.Normalize();
        move *= speed;

        this.transform.Translate(move);
    }
}
