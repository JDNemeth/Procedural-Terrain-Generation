using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotated : MonoBehaviour
{

    public Rotator Gravity;
    private Rigidbody rb;
    private float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Gravity)
        {
            
            Vector3 gravityUp = (transform.position - Gravity.transform.position).normalized; //smerovy vektor medzi hracom a stredom planety

            Vector3 localUp = transform.up; //(0, y, 0) poziacia hraca
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
