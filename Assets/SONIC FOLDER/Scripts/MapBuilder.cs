using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MapBuilder : MonoBehaviour
{
    public static MapBuilder Instance;

    [SerializeField] private Transform TrapContainer;
    [SerializeField] private Transform ForestPlatformContainer;
    [SerializeField] private Transform BrokenPlatformContainer;
    [SerializeField] private Transform OtherEnvironmentContainer;



    private void Awake()
    {
        Instance = this;

    }
    private void InstantiatingTraps(SonicLevelSO sonicLevel) 
    {
        if (!sonicLevel.isThereAnyTrap)
            return;

        for (int i = 0; i < sonicLevel.trapPositions.Count; i++)
        {
            GameObject trap = Instantiate(sonicLevel.trap, TrapContainer) as GameObject;
            trap.transform.position = sonicLevel.trapPositions[i];
            trap.transform.eulerAngles = new Vector3(0, 0, sonicLevel.trapRotations[i]);
            trap.transform.localScale = sonicLevel.trapScales[i];
        }

    }
    private void InstantiatingForestPlatforms(SonicLevelSO sonicLevel) 
    {
        if (!sonicLevel.isThereAnyForestPlatform)
            return;

        for (int i = 0; i < sonicLevel.forestPlatformPositions.Count; i++)
        {
            GameObject forestPlatform = Instantiate(sonicLevel.forestPlatform, ForestPlatformContainer) as GameObject;
            forestPlatform.transform.position = sonicLevel.forestPlatformPositions[i];
            forestPlatform.transform.localScale = sonicLevel.forestPlatformScales[i];
        }


    }
    private void InstantiatingBrokenPlatforms(SonicLevelSO sonicLevel)
    {
        if (!sonicLevel.isThereAnyBrokenPlatform)
            return;

        for (int i = 0; i < sonicLevel.brokenPlatformPositions.Count; i++)
        {
            GameObject brokenPlatform = Instantiate(sonicLevel.brokenPlatform, BrokenPlatformContainer) as GameObject;
            brokenPlatform.transform.position = sonicLevel.brokenPlatformPositions[i];
            brokenPlatform.transform.localScale = sonicLevel.brokenPlatformScales[i];
        }

    }
    private void InstantiatingClayWall(SonicLevelSO sonicLevel)
    {
        if (!sonicLevel.isThereAnyClayWall)
        return;

        for(int i = 0; i <sonicLevel.clayWallPositions.Count; i++)
        {
            GameObject clayWall = Instantiate(sonicLevel.clayWall,OtherEnvironmentContainer) as GameObject;
            clayWall.transform.position = sonicLevel.clayWallPositions[i];
            clayWall.transform.localScale = sonicLevel.clayWallScales[i];
            clayWall.transform.eulerAngles = new Vector3(0,0,sonicLevel.clayWallRotations[i]);

           
        }
        
    }
    private void InstantiatingTreeWall(SonicLevelSO sonicLevel)
    {
        if (!sonicLevel.isThereAnyTreeWall)
            return;

        for(int i = 0; i < sonicLevel.treeWallPositions.Count; i++)
        {
            GameObject treeWall = Instantiate(sonicLevel.treeWall, OtherEnvironmentContainer) as GameObject;
            treeWall.transform.position = sonicLevel.treeWallPositions[i];
            treeWall.transform.localScale = sonicLevel.treeWallScales[i];

        }
    }
    private void InstantiatingGoldCoins(SonicLevelSO sonicLevel)
    {
        for(int i= 0; i<sonicLevel.goldCoinPositions.Count; i++)
        {
            GameObject goldCoin = Instantiate(sonicLevel.goldCoin, OtherEnvironmentContainer) as GameObject;
            goldCoin.transform.position = sonicLevel.goldCoinPositions[i];
            goldCoin.transform.localScale = sonicLevel.goldCoinScales[i];
        }
    }
    private void InstantiatingTreePrefab(SonicLevelSO sonicLevel)
    {
        for(int i = 0; i< sonicLevel.treePrefabPositions.Count; i++)
        {
            GameObject treePrefab = Instantiate(sonicLevel.treePrefab, OtherEnvironmentContainer) as GameObject;
            treePrefab.transform.position = sonicLevel.treePrefabPositions[i];
            treePrefab.transform.localScale = sonicLevel.treePrefabsScales[i];
        }
    }
    private void InstantiateBGLayers(SonicLevelSO sonicLevel)
    {
        Canvas currentCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        GameObject bgLayers = Instantiate(sonicLevel.currentBGLayer,currentCanvas.transform);



        
    }

    public void BuildingLevel(SonicLevelSO sonicLevel)
    {
        if (sonicLevel == null)
            return;
        InstantiateBGLayers(sonicLevel);
        InstantiatingTraps(sonicLevel);
        InstantiatingForestPlatforms(sonicLevel);
        InstantiatingBrokenPlatforms(sonicLevel);
        InstantiatingClayWall(sonicLevel);
        InstantiatingGoldCoins(sonicLevel);
        InstantiatingTreeWall(sonicLevel);
        InstantiatingTreePrefab(sonicLevel);
        

    }
    public void ClearContainers()
    {
      
        foreach (Transform trap in TrapContainer.transform)
        {
            GameObject.Destroy(trap.gameObject);
        }
        foreach (Transform forestPlatform in ForestPlatformContainer.transform)
        {
            if (forestPlatform != null)
            {
                GameObject.Destroy(forestPlatform.gameObject);
            }
        }
        foreach (Transform brokenPlatform in BrokenPlatformContainer.transform)
        {
            if (brokenPlatform != null)
            {
                GameObject.Destroy(brokenPlatform.gameObject);
            }
        }
        foreach (Transform otherObjects in OtherEnvironmentContainer.transform)
        {
            if (otherObjects != null)
            {
                GameObject.Destroy(otherObjects.gameObject);
            }
        }

        Canvas currentCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        foreach(Transform bgLayer in currentCanvas.transform)
        {
            if(bgLayer != null)
            {
                GameObject.Destroy(bgLayer.gameObject);
            }
        }

    }

    public Transform GetOtherThingsContainer()
    {
        return OtherEnvironmentContainer;
    }
}
