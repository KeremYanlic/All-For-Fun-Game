using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OnPressStar : MonoBehaviour
{
    public static OnPressStar Instance { get; private set; }
    
    public event EventHandler<OnPressStarObjectEventArgs> OnPressStarObject;
    public event EventHandler<OnBuildLevelEventArgs> OnBuildLevel;
    public class OnPressStarObjectEventArgs : EventArgs { public GameObject selectedStar; }
    public class OnBuildLevelEventArgs : EventArgs
    {
        public int starCount;
        public int starIndex;
    }
    public void CallOnBuildLevelEvent(int starCount,int starIndex)
    {
        OnBuildLevel?.Invoke(this, new OnBuildLevelEventArgs() { starCount = starCount, starIndex = starIndex });
    }
    
    [HideInInspector] public GameObject selectedPiece;
    private int starCount;
    private int starIndex;
    private Vector3 pressPos = Vector3.zero;

   

     [HideInInspector] public bool canPressStar;
   
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        OnPressStarObject += OnPressStar_OnPressStarObject;
        OnBuildLevel += OnPressStar_OnBuildLevel;
    }

   
    private void OnDisable()
    {
        OnPressStarObject -= OnPressStar_OnPressStarObject;
        OnBuildLevel -= OnPressStar_OnBuildLevel;
    }
    // Update is called once per frame
    void Update()
    {
        if (canPressStar)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D ray = Physics2D.Raycast(HSUtilsClass.GetWorldMousePosition(), Vector2.zero);
                if (ray.collider == null)
                {
                    return;
                }
                else
                {
                    if (ray.collider.CompareTag("star"))
                    {
                        selectedPiece = ray.collider.gameObject;
                        if (selectedPiece == null)
                            return;
                        if (selectedPiece.transform.position != pressPos)
                        {
                            if (selectedPiece.GetComponent<PfStar>().canPressStar)
                            {
                                pressPos = selectedPiece.transform.position;
                                OnPressStarObject?.Invoke(this, new OnPressStarObjectEventArgs { selectedStar = selectedPiece });
                            }


                        }




                    }
                }
            }
        }
      
    }
    private void OnPressStar_OnBuildLevel(object sender, OnBuildLevelEventArgs onBuildLevelEventArgs)
    {
        starCount = onBuildLevelEventArgs.starCount;
        starIndex = onBuildLevelEventArgs.starIndex;
    }

    private void OnPressStar_OnPressStarObject(object sender, OnPressStarObjectEventArgs onPressStarObjectEventArgs)
    {
        OnClickStarEventMethod(onPressStarObjectEventArgs);
        InstantiatingStarParticle(onPressStarObjectEventArgs);
        IncreaseStarCount();
        starIndex++;
        StarControlPanel.Instance.CallPressStarControlPanel(starIndex);
    }


    private void OnClickStarEventMethod(OnPressStarObjectEventArgs onPressStarObjectEventArgs)
    {
        SpriteRenderer selectedStarSR = onPressStarObjectEventArgs.selectedStar.gameObject.GetComponent<SpriteRenderer>(); // Define stars sprite renderer
        onPressStarObjectEventArgs.selectedStar.GetComponent<PfStar>().canPressStar = false;
        selectedStarSR.color = DefineFullOpacityColor();
    }
    private void InstantiatingStarParticle(OnPressStarObjectEventArgs onPressStarObjectEventArgs)
    {
        GameObject starParticle = Resources.Load<GameObject>("StarParticle");
        Instantiate(starParticle, onPressStarObjectEventArgs.selectedStar.transform.position, Quaternion.identity);
    }

    private void IncreaseStarCount()
    {
        starCount++;
        if(starCount < 9) { return; }
        
    }
    public int GetStarCount()
    {
        return starCount;
    }

    public bool MissionCompleted()
    {
        return starCount >= 9;
    }

    public GameObject GetSelectedPiece()
    {
        return selectedPiece;
    }
    public int GetStarIndex()
    {
        return starIndex;
    }
    private Color DefineFullOpacityColor()
    {
        return HSUtilsClass.FullOpacity(255f, 255f, 0f, 255f);
    }
}
