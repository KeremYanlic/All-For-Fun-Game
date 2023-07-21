using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermAdvertisement : MonoBehaviour
{
    private float advertisementTimer;
    [SerializeField] private float advertisementTimerMax;


    // Start is called before the first frame update
    void Start()
    {
        advertisementTimer = advertisementTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        ShowAd();
    }

    private void ShowAd()
    {
        advertisementTimer -= Time.deltaTime;

        if(advertisementTimer <= 0f)
        {
            advertisementTimer += advertisementTimerMax;
#if UNITY_WEBGL
            GameMonetize.Instance.ShowAd();
#endif
        }
    }
}
