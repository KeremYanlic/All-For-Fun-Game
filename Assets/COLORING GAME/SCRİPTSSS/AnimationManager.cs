using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Vector3 flowPos;
    [SerializeField] private float flowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FlowAnimAtStart(flowPos, flowSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FlowAnimAtStart(Vector3 flowPos,float flowSpeed)
    {
        LeanTween.moveLocal(gameObject, flowPos, flowSpeed);
    }
}
