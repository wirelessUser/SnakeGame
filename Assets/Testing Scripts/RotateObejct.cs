using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObejct : MonoBehaviour

{
     Vector3 startRotaion;
     float t=0;
    private void Start()
    {
        startRotaion = transform.rotation.eulerAngles;
        
    }


    private void FixedUpdate()
    {
        float zroation;
        zroation = startRotaion.z;


        t += 0.01f;
        startRotaion.z = Mathf.Lerp(zroation, 45, t);
      
       // startRotaion = new Vector3(0, 0, startRotaion.z);
    transform.rotation = Quaternion.Euler(0, 0, startRotaion.z);

    }

















}



















//    #region
//    //public float rotationSpeed = 80f; // rotation speed in degrees per second

//    //private Quaternion startRotation;
//    //private float currentRotation = 0f;

//    //void Start()
//    //{
//    //    //   start roitation value 
//    //    startRotation = transform.rotation;
//    //    Debug.Log("startRotation" + startRotation);
//    //}

//    //void Update()
//    //{
//    //    if (currentRotation < 45f)
//    //    {
//    //        // setting rotation Amount Based on rotaion speed & using time.deltatime
//    //        float rotationAmount = rotationSpeed * Time.deltaTime;

//    //        Debug.Log("rotationAmount" + rotationAmount);

//    //        // Calculate the new rotation based on the current rotation amount
//    //        Quaternion newRotation = Quaternion.Euler(0f, 0f, currentRotation + rotationAmount);

//    //        Debug.Log("newRotation" + newRotation);


//    //        // Apply the new rotation to the object's transform
//    //        transform.rotation = startRotation * newRotation;

//    //     //  why += cannot applied to Operant type Quternion and Quetrnion

//    //        // Increment the current rotation
//    //        currentRotation += rotationAmount;

//    //        Debug.Log("currentRotation>>" + currentRotation);


//    //        Debug.Log("=================================================================>>" );
//    //    }
//    //}

//    #endregion












//    private float rotationSpeed = 0.01f; // rotation speed in degrees per second
//    private float currentRotation = 0f;

//    public Quaternion startRotation;
//    public Quaternion targetRotation;
//    float speed = 0.01f;
//    float timeCount = 0.0f;

//    #region
//    //public float rotationSpeed = 60f; // rotation speed in degrees per second


//    //public float currentRotation = 0f;

//    //#region
//    ////if (Input.GetKey(KeyCode.Space))
//    ////{
//    ////    if (currentRotation < 90f)
//    ////    {
//    ////        float rotationAmount = rotationSpeed * Time.deltaTime;
//    ////        transform.Rotate(Vector3.forward, rotationAmount);
//    ////        currentRotation += rotationAmount;
//    ////    }


//    //#endregion



//
////    {
//        //if (Input.GetKey(KeyCode.Space))
//        //{
//            if (currentRotation < 90f)
//            {
//                // Calculate the rotation amount based on the rotation speed and time elapsed
//                float rotationAmount = 30 * Time.deltaTime;
//                Debug.Log("rotationAmount>>" + rotationAmount);

//            // Interpolate between the starting and target rotations based on the current rotation amount
//             Quaternion newRotation = Mathf.Lerp(startRotation, targetRotation, timeCount * speed);
//           // Quaternion newRotation = Quaternion.Slerp(startRotation, targetRotation, currentRotation/180);
//            Debug.Log("currentRotation / 90f>>" + rotationAmount);
//                // Apply the new rotation to the object's transform
//                transform.rotation = newRotation;
//               // Debug.Log("newRotation>>" + newRotation);
//                // Increment the current rotation
//                currentRotation += rotationAmount;
//              //  Debug.Log("currentRotation>>" + currentRotation);
//            timeCount += Time.deltaTime;
//            Debug.Log("timeCount>>" + timeCount);
//        }


//        //}



//    }


//    #endregion



//}