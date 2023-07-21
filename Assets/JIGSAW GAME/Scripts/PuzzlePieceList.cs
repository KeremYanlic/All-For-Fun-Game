using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceList : MonoBehaviour
{
    public static PuzzlePieceList Instance;

    public List<GameObject> AllObjects;

    private void Awake()
    {
        Instance = this;
    }

}
