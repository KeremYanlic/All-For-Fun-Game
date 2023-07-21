using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameSelectSM : MonoBehaviour
{
    private Image coloringGame;
    private Image hiddenStarGame;
    private Image jigsawGame;
    private Image runnerGame;

    private Image filtre;
    private Image filtre1;
    private Image filtre2;
    private Image filtre3;

    private TextMeshProUGUI ColoringGameText;
    private TextMeshProUGUI HiddenStarGameText;
    private TextMeshProUGUI JigsawGameText;
    private TextMeshProUGUI RunnerGameText;

    private Button coloringGameBtn;
    private Button jigsawGameBtn;
    private Button hiddenStarGameBtn;
    private Button runnerGameBtn;
 

    [SerializeField] private float gameImagesScaleTime;
    [SerializeField] private float textPositionTime;
    [SerializeField] private float buttonScaleTime;
    [SerializeField] private float upperLocalY;
    [SerializeField] private float lowerLocalY;

    // Start is called before the first frame update
    void Start()
    {
        coloringGame = transform.Find("coloringGame").GetComponent<Image>();
        hiddenStarGame = transform.Find("hiddenStarGame").GetComponent<Image>();
        jigsawGame = transform.Find("jigsawGame").GetComponent<Image>();
        runnerGame = transform.Find("runnerGame").GetComponent<Image>();

        filtre = transform.Find("filtre").GetComponent<Image>();
        filtre1 = transform.Find("filtre1").GetComponent<Image>();
        filtre2 = transform.Find("filtre2").GetComponent<Image>();
        filtre3 = transform.Find("filtre3").GetComponent<Image>();

        ColoringGameText = transform.Find("ColoringGameText").GetComponent<TextMeshProUGUI>();
        HiddenStarGameText = transform.Find("HiddenStarGameText").GetComponent<TextMeshProUGUI>();
        JigsawGameText = transform.Find("PuzzleGameText").GetComponent<TextMeshProUGUI>();
        RunnerGameText = transform.Find("RunnerGameText").GetComponent<TextMeshProUGUI>();

        coloringGameBtn = transform.Find("coloringGameBtn").GetComponent<Button>();
        jigsawGameBtn = transform.Find("puzzleGameBtn").GetComponent<Button>();
        hiddenStarGameBtn = transform.Find("hiddenStarGameBtn").GetComponent<Button>();
        runnerGameBtn = transform.Find("runnerGameBtn").GetComponent<Button>();

        LeanTween.scale(coloringGame.gameObject, new Vector3(1f, 1f, 0), gameImagesScaleTime).setEaseInOutBack().setOnComplete(SetTextPositios);
        LeanTween.scale(hiddenStarGame.gameObject, new Vector3(1f, 1f, 0), gameImagesScaleTime).setEaseInOutBack().setOnComplete(SetButtonsScaled);
        LeanTween.scale(jigsawGame.gameObject, new Vector3(1f, 1f, 0), gameImagesScaleTime).setEaseInOutBack();
        LeanTween.scale(runnerGame.gameObject, new Vector3(1f, 1f, 0), gameImagesScaleTime).setEaseInOutBack().setOnComplete(SetFiltreScale);

        jigsawGameBtn.onClick.AddListener(() => { SceneManager.LoadScene("PuzzleMainScene"); });
        coloringGameBtn.onClick.AddListener(() => { SceneManager.LoadScene("ColoringMM"); });
        hiddenStarGameBtn.onClick.AddListener(() => { SceneManager.LoadScene("HDStarLevelMenu"); });
        runnerGameBtn.onClick.AddListener(() => { SceneManager.LoadScene("SonicMainMenu");});  
    }
    private void SetFiltreScale()
    {
        LeanTween.scale(filtre.gameObject, new Vector3(1f, 1f, 0),0).setEaseInBack();
        LeanTween.scale(filtre1.gameObject, new Vector3(1f, 1f, 0),0).setEaseInBack();
        LeanTween.scale(filtre2.gameObject, new Vector3(1f, 1f, 0),0).setEaseInBack();
        LeanTween.scale(filtre3.gameObject, new Vector3(1f, 1f, 0),0).setEaseInBack();

    }
    private void SetTextPositios()
    {
        LeanTween.moveLocalY(ColoringGameText.gameObject, upperLocalY, textPositionTime);
        LeanTween.moveLocalY(HiddenStarGameText.gameObject, upperLocalY, textPositionTime);
        LeanTween.moveLocalY(JigsawGameText.gameObject, lowerLocalY, textPositionTime);
        LeanTween.moveLocalY(RunnerGameText.gameObject, lowerLocalY, textPositionTime);

    }
    private void SetButtonsScaled()
    {
        LeanTween.scale(coloringGameBtn.gameObject, new Vector3(1, 1), buttonScaleTime).setEaseInBack();
        LeanTween.scale(jigsawGameBtn.gameObject, new Vector3(1, 1), buttonScaleTime).setEaseInBack();
        LeanTween.scale(hiddenStarGameBtn.gameObject, new Vector3(1, 1), buttonScaleTime).setEaseInBack();
        LeanTween.scale(runnerGameBtn.gameObject, new Vector3(1, 1), buttonScaleTime).setEaseInBack();
    }
    
}
