using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HDStarSO/Create New Image SO",fileName = "HDStarImageSO_")]
public class HDStarSO : ScriptableObject
{
    public List<Sprite> bgImageList;


    public GameObject starPrefab;
    public List<GameObject> starPrefabList;
}
