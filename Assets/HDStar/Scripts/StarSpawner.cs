using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public static StarSpawner Instance { get; private set; }


    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private Transform starContainer;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }

    public void InitialiseStars(HDStarSO hDStarSO)
    {
        for (int i = 0; i<hDStarSO.starPrefabList.Count; i++)
        {
           GameObject stars = Instantiate(hDStarSO.starPrefab,starContainer);
           stars.transform.position = new Vector3(GetRandomXPosition(), minY + (Mathf.Abs(maxY - minY) / hDStarSO.starPrefabList.Count) * i + 1);
            stars.transform.localEulerAngles = new Vector3(0f, 0f, GetRandomAngle());
        }
    }
    public void ClearContainer()
    {
        foreach(Transform star in starContainer)
        {
            if(star.gameObject != null)
            {
                Destroy(star.gameObject);
            }
         
        }
    }
    public float GetRandomXPosition()
    {
        return Random.Range(minX, maxX);
    }
    public float GetRandomAngle()
    {
        return Random.Range(0, 180);
    }
    
}
