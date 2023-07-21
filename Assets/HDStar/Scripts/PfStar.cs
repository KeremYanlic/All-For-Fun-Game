using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfStar : MonoBehaviour
{
    public static PfStar Instance;



    public bool canPressStar;

    private void Awake()
    {
        canPressStar = true;
        Instance = this;
    }
 
}
