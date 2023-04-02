using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCode : MonoBehaviour
{
    float xPos = 0;
    public GameObject yellowPrefab;
    int j = 0;
    int k = 0;
    float time = 5;
    float initTime = 0;
    public GameObject white;
    public float speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //transform.position = Vector3.MoveTowards(this.transform.position, yellowPrefab.transform.position, 0.01f);// it will ove 0.1 units per frame .; 
        //Vector2.Distance(this.transform.position, yellowPrefab.transform.position);

        //Vector2 direction = yellowPrefab.transform.position - this.transform.position;
        //Debug.Log("direction>>" + direction);
        //float dist = direction.magnitude;
        //Debug.Log("dist>>"+ dist);
        //// Normalize Dire ctio vector............
        //Vector3 normalDir = direction.normalized;
        //Debug.Log("normalDir>>" + normalDir);

        Debug.Log("<<===============================================================================================>>" );

        Vector3 v = yellowPrefab.transform.position - this.transform.position;
        Debug.Log("v>>" + v);
        float magnitude = Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        Debug.Log("magnitude>>" + magnitude);
        Vector3 normalized = new Vector3(v.x / magnitude, v.y / magnitude, v.z / magnitude);
        Debug.Log("normalized>>" + normalized);
        float mag1 = normalized.x;
        float mag2 = normalized.y;
        Debug.Log("mag_1>>" + mag1);
        Debug.Log("mag_2>>" + mag2);
        transform.LookAt(yellowPrefab.transform, Vector3.up);
       // transform.rotation = Quaternion.Euler(new Vector3(mag1, mag2, 0));
        if (Mathf.Abs(magnitude) >=0)
        {
            transform.position += new Vector3(/*Mathf.Abs*/(mag1), /*Mathf.Abs*/(mag2), 0);
            Debug.Log("transform.position>>" + transform.position);
        }
         

        #region
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {

        //            #region  why this code not moving the gameObejct ?
        //            //+= 1f;
        //            //transform.position.Set(xPos, 0, 0); /// why this code not moving the gameObejct ?
        //            #endregion why this code not moving the gameObejct ?

        //            #region Formula for pixel calculation ina pixel of  256 Sprite and 1 Pixel Spritwes.
        //            //for (int i = 0; i < 256; i++)
        //            //{

        //            //    GameObject yellow = Instantiate(yellowPrefab);
        //            //    yellow.transform.position = new Vector3(-127.5f, 127.5f, 0) + new Vector3(j,0,0);
        //            //    j += 1;
        //            //}
        //            //for (int i = 0; i < 256; i++)
        //            //{
        //            //    Debug.Log("callinmg Second For Loop");
        //            //    GameObject yellow = Instantiate(yellowPrefab);
        //            //    yellow.transform.position = new Vector3(-127.5f, 127.5f, 0) + new Vector3( 0, k,0);
        //            //    k -= 1;
        //            //}

        //            /*
        //            In Unity, the sprite size is measured in pixels per unit (PPU). PPU is a measure of how many pixels in the sprite correspond to one unit of world space in the scene. For example, if a sprite has a PPU value of 100, then each pixel in the sprite corresponds to 1/100th of a unit in the scene.

        //The reason why the smallest sprite size is mentioned as 256 pixels per unit is because this is the default value for the Pixels Per Unit setting when creating a new sprite in Unity. This value is chosen because it is a power of two (2^8), which makes it easy to work with when scaling sprites up or down.

        //As for the biggest sprite size being 1 pixel per unit, this is because Unity's rendering system has a limit on the maximum texture size that can be used for a sprite. This limit depends on the graphics hardware and the platform that the game is running on, but it is typically around 4096 pixels on a side. If you were to use a sprite with a PPU value greater than 1, and the sprite had a large number of pixels, the resulting texture would exceed the maximum texture size and would not be able to be rendered.

        //Therefore, if you need to use a large sprite, you would typically reduce the PPU value so that each pixel in the sprite corresponds to a larger unit in the scene. This would reduce the size of the resulting texture and allow it to be rendered within the maximum texture size limit. a sprite. This limit depends on the graphics hardware and the platform that the game is running on, but it is typically around 4096 pixels on a side. If you were to use a sprite with a PPU value greater than 1, and the sprite had a large number of pixels, the resulting texture would exceed 
        //             **/

        //            #endregion
        //        }

        #endregion
        //  white.transform.position += new Vector3(0.3f, 0);

        // initTime += Time.deltaTime;
        //// print("Time completed " + initTime + "..." + time);
        // if (initTime >= time)
        // {
        //     //print("Finasl>>>>>>>>>>Time completed " + initTime + "..."+ time);
        //     return;
        // }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Caleld destroy");

            StartCoroutine(WaitDestroy());
            Debug.Log("I am calleed  After Coroutine ");
            



        }
    }// end Update


      IEnumerator WaitDestroy()
    {
        Debug.Log("Caleld IEnumerator");
        yield return new WaitForSeconds(5);
        Debug.Log("I am calleed  INISDE>>> Coroutine ");
        Destroy(yellowPrefab);
    }










} // end Class .........
