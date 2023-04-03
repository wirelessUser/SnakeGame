using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridgen : MonoBehaviour
{
    public GameObject gridPrefab;



    private void Awake()
    {
      Grid gridObj = new Grid(18, 10, 1, gridPrefab); 


       

    }


}
