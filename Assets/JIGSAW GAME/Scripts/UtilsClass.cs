using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass 
{
   
    public static Vector3 GetMouseWorldPos(GameObject puzzle)
    {
        
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        return worldPos;
    }
    
}
