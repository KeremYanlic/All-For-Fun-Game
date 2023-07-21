using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSettingManager : MonoBehaviour
{
    private Button menuBtn;

    private void Awake()
    {
        menuBtn = transform.Find("menuBtn").GetComponent<Button>();

        menuBtn.onClick.AddListener(() => {
            SceneManagerSonic.Instance.LoadMainMenu();
            });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
