using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SonicLevelSO_",menuName = "SonicSO")]
public class SonicLevelSO : ScriptableObject
{
    #region Header
    [Header("TRAPS !!!!")]
    [Space(10)]
    #endregion
    #region Tooltip
    [Tooltip("Check if this specific level contains any trap gameobject")]
    #endregion
    public bool isThereAnyTrap;

    #region Tooltip
    [Tooltip("Trap Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject trap;

    #region Tooltip
    [Tooltip("Trap positions to spawn")]
    #endregion Tooltip
    public List<Vector3> trapPositions;

    #region Tooltip
    [Tooltip("Rotation of these traps")]
    #endregion
    public List<int> trapRotations;

    #region Tooltip
    [Tooltip("Scale of these traps")]
    #endregion
    public List<Vector3> trapScales;

    #region Header
    [Header("FOREST PLATFORMS !!!!")]
    [Space(10)]
    #endregion

    #region Tooltip
    [Tooltip("Check if this specific level contains any forestPlatform gameobject")]
    #endregion
    public bool isThereAnyForestPlatform;

    #region Tooltip
    [Tooltip("forestPlatform Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject forestPlatform;

    #region Tooltip
    [Tooltip("forestPlatform positions to spawn")]
    #endregion Tooltip
    public List<Vector3> forestPlatformPositions;

    #region Tooltip
    [Tooltip("Scales of forest platforms")]
    #endregion
    public List<Vector3> forestPlatformScales;


    #region Header
    [Header("BROKEN PLATFORMS !!!!")]
    [Space(10)]
    #endregion

    #region Tooltip
    [Tooltip("Check if this specific level contains any brokenPlatform gameobject")]
    #endregion
    public bool isThereAnyBrokenPlatform;

    #region Tooltip
    [Tooltip("brokenPlatform Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject brokenPlatform;

    #region Tooltip
    [Tooltip("brokenPlatformDestroyTime")]
    #endregion Tooltip
    public float brokenPlatformDestroyTime;

    #region Tooltip
    [Tooltip("brokenPlatform positions to spawn")]
    #endregion Tooltip
    public List<Vector3> brokenPlatformPositions;

    #region Tooltip
    [Tooltip("Scales of broken platforms")]
    #endregion
    public List<Vector3> brokenPlatformScales;


    #region Header
    [Header("CLAY WALL !!!!")]
    [Space(10)]
    #endregion

    #region Tooltip
    [Tooltip("Check if this specific level contains any clay wall gameobject")]
    #endregion
    public bool isThereAnyClayWall;

    #region Tooltip
    [Tooltip("Clay wall Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject clayWall;

    #region Tooltip
    [Tooltip("Clay wall positions to spawn")]
    #endregion Tooltip
    public List<Vector3> clayWallPositions;

    #region Tooltip
    [Tooltip("Clay wall rotations")]
    #endregion Tooltip
    public List<float> clayWallRotations;

    #region Tooltip
    [Tooltip("Scales of clay wall")]
    #endregion
    public List<Vector3> clayWallScales;

    #region Header
    [Header("TREE WALL !!!!")]
    [Space(10)]
    #endregion


    #region Tooltip
    [Tooltip("Check if this specific level contains any tree wall gameobject")]
    #endregion
    public bool isThereAnyTreeWall;

    #region Tooltip
    [Tooltip("Tree wall Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject treeWall;

    #region Tooltip
    [Tooltip("Tree wall positions to spawn")]
    #endregion Tooltip
    public List<Vector3> treeWallPositions;

    #region Tooltip
    [Tooltip("Scales of tree wall")]
    #endregion
    public List<Vector3> treeWallScales;

    #region Header
    [Header("GOLD COIN !!!!")]
    [Space(10)]
    #endregion

    #region Tooltip
    [Tooltip("Gold coin Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject goldCoin;

    #region Tooltip
    [Tooltip("Gold coin amount at this SonicLevelSO")]
    #endregion Tooltip
    public int goldCoinAmount;

    #region Tooltip
    [Tooltip("Gold coin positions to spawn")]
    #endregion Tooltip
    public List<Vector3> goldCoinPositions;

    #region Tooltip
    [Tooltip("Scales of gold coin")]
    #endregion
    public List<Vector3> goldCoinScales;


    #region Header
    [Header("PORTAL !!!!")]
    [Space(10)]
    #endregion

    #region Tooltip
    [Tooltip("Portal Gameobject to Instantiate")]
    #endregion Tooltip
    public GameObject portal;

    #region Tooltip
    [Tooltip("Check whether this portal has platform or not")]
    #endregion Tooltip
    public bool isPortalHasPlatform;

    #region Tooltip
    [Tooltip("Position of portal")]
    #endregion
    public Vector3 portalPosition;

    #region HEADER
    [Header("General Display Part of the GAME")]
    [Space(10)]
    #endregion

    #region Tooltip
    [Tooltip("Walls but their images are trees.")]
    #endregion
    public GameObject treePrefab;

    #region Tooltip
    [Tooltip("Positions of treePrefabs")]
    #endregion
    public List<Vector2> treePrefabPositions;

    #region Tooltip
    [Tooltip("Scales of treePrefabs")]
    #endregion
    public List<Vector2> treePrefabsScales;

    #region CANVAS LAYER GAMEOBJECT
    [Tooltip("Cabvas Layer Images")]
    #endregion
    public GameObject currentBGLayer;
}
