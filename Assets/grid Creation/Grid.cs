using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
   private  int width;
    private int height;
    private float cellSize=1;
    private int[,] gridArray;

    #region
    // public GameObject gridPrefab;
    //private void Awake()
    //{
    //    width = 18;
    //    height = 10;
    //    gridArray = new int[width, height];

    //    cellSize = 1;

    //    Debug.Log("calling Awake from grid");

    //    for (int i = 0; i < gridArray.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < gridArray.GetLength(1); j++)
    //        {

    //            GameObject gridPre = Instantiate(gridPrefab);
    //            Vector2 pos = GetWorldPosition(i, j);
    //            Debug.Log("GetWorldPosition(i, j)" + GetWorldPosition(i, j));
    //            gridPre.transform.position = new Vector2(0.5f, 0.5f) + pos;
    //        }
    //    }
    //}//End Awake.......
    #endregion

    public Grid(int _width, int _height, float _cellSize,GameObject gridpre)
   {
         width = 18;
         height = 10;
        gridArray = new int[width, height];
       
     
       
       // Debug.Log("calling Awake from grid");

        for (int i = 0; i<gridArray.GetLength(0); i++)
        {
            for (int j = 0; j<gridArray.GetLength(1); j++)
            {
                
                GameObject gridPre = Instantiate(gridpre);
                   Vector2 pos = GetWorldPosition(i, j);
               // Debug.Log("GetWorldPosition(i, j)" + GetWorldPosition(i, j));
                gridPre.transform.position = new Vector2(0.5f, 0.5f) + pos;
                //gridpre.transform.SetParent(GameObject.Find("GrisdGen").transform);
            }
        }
    }



    public Vector2 GetWorldPosition(int x , int y)
    {
       // Debug.Log("Vector3(x, y) * cellSize" + new Vector3(x, y) );
        return new Vector3(x, y);

    }




}
