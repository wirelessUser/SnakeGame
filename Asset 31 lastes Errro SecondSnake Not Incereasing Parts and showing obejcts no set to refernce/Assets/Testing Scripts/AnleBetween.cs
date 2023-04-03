using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnleBetween : MonoBehaviour
{
    //public Transform vectorA;
    //public Transform vectorB;
    public Transform target;
    //void Update()
    //{
    //    //Vector3 A = vectorA.localPosition - transform.localPosition;
        //Vector3 B = vectorB.localPosition - transform.localPosition;

        //float dot = Vector3.Dot(A, B);
        //Debug.Log("dot>>> " + dot);
        //float angle = Mathf.Acos(dot / (A.magnitude * B.magnitude)) * Mathf.Rad2Deg;

        //Debug.Log("Angle between A and B: " + angle);
         

    void Update()
    {
        Vector3 direction = target.localPosition - transform.localPosition;
        float angle = Vector3.Angle(target.localPosition, direction);

        Debug.Log("Angle between forward direction and target: " + angle);
    }


//}
}







//startRotation = transform.rotation;
//targetRotation = Quaternion.Euler(0f, 0f, 90);
//    }

//    void FixedUpdate()
//{
//    if (Input.GetKey(KeyCode.Space))
//    {
//        if (currentRotation < 90f)
//        {
//            // Calculate the rotation amount based on the rotation speed and time elapsed
//            float rotationAmount = rotationSpeed * Time.deltaTime;

//            //using Quaternion.Lerp
//            Quaternion newRotation = Quaternion.Lerp(startRotation, targetRotation, t);

//            // setting the Rotation of Obejct 
//            transform.rotation = newRotation;

//            currentRotation += rotationAmount;

//        }
//    }
























