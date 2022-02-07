using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField]
    GameObject FollowTarget = null;

    Vector3 distance = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - FollowTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = FollowTarget.transform.position + distance;
    }
}
