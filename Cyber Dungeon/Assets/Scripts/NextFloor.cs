using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloor : MonoBehaviour
{
    [SerializeField]
    GameObject mapCreator;

    void OnTriggerEnter(Collider other)
    {
        if (!mapCreator)
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            mapCreator.GetComponent<MapCreator>().Generate();
        }
    }


}
