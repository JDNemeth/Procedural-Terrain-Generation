using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float Gravity;

    private void OnTriggerEnter(Collider other)
    { 
        if (other.GetComponent<Rotated>())
        {
            other.GetComponent<Rotated>().Gravity = this.GetComponent<Rotator>();
        }
    }
}
