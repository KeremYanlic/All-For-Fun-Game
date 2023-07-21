using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
public class DragAndDrop : MonoBehaviour
{
    public static DragAndDrop Instance { get; private set; }

    public event Action<DragAndDrop> OnMouseUp;
    
    public void CallMouseUpEvent()
    {
        OnMouseUp?.Invoke(this);
    }

    private Camera cam;
    public GameObject selectedPiece;

    private int sortingOrderCount;

    public bool allowToConnect;

    public bool allowToPuzzle;

    public float timer = 4f;
    private void Awake()
    {
        Instance = this;

        cam = Camera.main;
    }
    // Start is called before the first frame update

    private void OnEnable()
    {
        OnMouseUp += DragAndDrop_OnMouseUp;
    }
    private void Start()
    {
       

        allowToPuzzle = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (ray.collider != null)
            {
                if (ray.collider.CompareTag("puzzle"))
                {
                    selectedPiece = ray.collider.gameObject;
                }
            }

        }
       /* if(selectedPiece != null)
        {
            if (selectedPiece.GetComponent<PiecesScript>().ConnectedObjects.Count != 0)
            {
                foreach (GameObject puzzleObject in selectedPiece.GetComponent<PiecesScript>().ConnectedObjects.ToArray())
                {
                    foreach (GameObject childObject in puzzleObject.GetComponent<PiecesScript>().ConnectedObjects.ToArray())
                    {
                        if (childObject != null)
                        {
                            if (!selectedPiece.GetComponent<PiecesScript>().ConnectedObjects.Contains(childObject))
                            {
                                selectedPiece.GetComponent<PiecesScript>().ConnectedObjects.Add(childObject);
                            }
                        }
                    }
                }
            }
        } 
     */

        sortingOrderCount++;



        if (selectedPiece != null)
            {
               
                if (IsSelectedPieceAlone(selectedPiece))
                {
 
                    selectedPiece.GetComponent<PiecesScript>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = sortingOrderCount;
                    
                }
               
                if (!IsSelectedPieceAlone(selectedPiece))
                {
                    selectedPiece.GetComponent<PiecesScript>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = sortingOrderCount;


                     foreach (GameObject gameObject in selectedPiece.GetComponent<PiecesScript>().ConnectedObjects)
                      {
                        if (gameObject)
                        {
                            selectedPiece.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = sortingOrderCount;
                            gameObject.transform.SetParent(selectedPiece.transform);
                        }
                       
                      }
                }


            }
            else { selectedPiece = null; }


            if (Input.GetMouseButtonUp(0))
            {
                CallMouseUpEvent();
                 

                if (selectedPiece != null)
                {
                   #region UnnecessaryForNow
                    foreach (GameObject gameObject in selectedPiece.GetComponent<PiecesScript>().ConnectedObjects)
                    {
                        if (gameObject.CompareTag("puzzle"))
                        {
                            gameObject.transform.parent = null;

                        }
                    }
                    #endregion
                    selectedPiece.GetComponent<PiecesScript>().selected = false;
                    selectedPiece = null;

                }

            }

    }
    private void DragAndDrop_OnMouseUp(DragAndDrop dragAndDrop)
    {
        StartCoroutine(ConnectTimer());
    }

    private IEnumerator ConnectTimer()
    {
        allowToConnect = true;
        yield return new WaitForSeconds(0.1f);
        allowToConnect = false;
    }
    public bool AllowingToConnect()
    {
        return allowToConnect;
    }
 
    private bool IsSelectedPieceAlone(GameObject selectedPiece)
    {
        if (selectedPiece.GetComponent<PiecesScript>().ConnectedObjects.Count == 0)
        {
            return true;
        }
        else { return false; }

    }
  
    public GameObject GetSelectedPiece()
    {
        return selectedPiece;
    }
}
