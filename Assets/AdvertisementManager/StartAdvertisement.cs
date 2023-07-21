using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAdvertisement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        GameMonetize.Instance.ShowAd();
#endif
    }
}
