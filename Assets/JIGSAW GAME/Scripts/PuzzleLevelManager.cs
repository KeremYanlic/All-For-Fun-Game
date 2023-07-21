using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PuzzleLevelManager : MonoBehaviour
{
    public List<Image> LevelButtons;

   

    // Start is called before the first frame update
    void Start()
    {
     

        int levelReached = PlayerPrefs.GetInt("puzzleLevelReached", 1);
        PlayerPrefs.SetInt("puzzleLevelReached", levelReached);
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if (i + 1 > levelReached)
            {
                LevelButtons[i].GetComponent<Button>().interactable = false;
               
               
            }
            else
            {
                LevelButtons[i].GetComponent<Button>().interactable = true;
                if(LevelButtons[i].gameObject != null)
                {
                    LevelButtons[i].gameObject.transform.Find("lockImage").GetComponent<Image>().enabled = false;
                }
                
            }
        }


       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSpecificLevel(int i)
    {
        SceneManager.LoadScene("PuzzleScene " + i);
    }
    public void LoadGameSelectMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }
  
}
