using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScript : MonoBehaviour
{
    public static PiecesScript Instance { get; private set; }

    #region Variables

    public List<GameObject> ClosestGameObjects;

    public List<GameObject> ConnectedObjects;
    [SerializeField] private float minX = -7;
    [SerializeField] private float maxX = 7;
    [SerializeField] private float minY = -4;
    [SerializeField] private float maxY = 4;

   
    public bool selected;

  
    public GameObject rightObject;
    public GameObject leftObject;
    public GameObject upObject;
    public GameObject downObject;

    private bool canConnectToRight;
    private bool canConnectToLeft;
    private bool canConncectToUp;
    private bool canConnectToDown;

    public bool connectedToRight;
    public bool connectedToLeft;
    public bool connectedToUp;
    public bool connectedToDown;


    private Vector2 rightVector;
    private Vector2 leftVector;
    private Vector2 upVector;
    private Vector2 downVector;

    private Vector3 mOffset;
    private BoxCollider2D boxCollider2D;
    public bool isShufflingDone = false;
    #endregion


    private void Awake()
    {
        Instance = this;

        boxCollider2D = GetComponent<BoxCollider2D>();


      //  DefineClosestGameObjects();
    }
 
    // Start is called before the first frame update
    void Start()
    {
        connectedToRight = false;
        connectedToDown = false;
        connectedToLeft = false;
        connectedToUp = false;

        DefineVectors();
   
        InvokeRepeating(nameof(Shuffling), 1f, 1f);
        Invoke(nameof(CancelShuffling), 4f);
    }
    // Update is called once per frame
    void Update()
    {
        SetConnectedObjects();
        if (DragAndDrop.Instance.allowToPuzzle)
        {
            if (selected)
            {
                SearchClosestItemsOfSelectedPiece();
                SearchClosestItemsOfConnectedObjects();
            }
           
        }
        AssembleThePieces();

        WinCondition();

    }
    private void OnMouseDown()
    {
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    private void OnMouseDrag()
    {
        if (DragAndDrop.Instance.allowToPuzzle && isShufflingDone)
        {
            gameObject.transform.position = GetMouseWorldPos() + mOffset;
        }
        
    }
    private Vector3 GetMouseWorldPos()
    {
        //Pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object on screen 
        mousePoint.z = 0;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void DefineVectors()
    {

        if (rightObject != null)
        {
            rightVector = rightObject.transform.position - transform.position;
        }
        if (leftObject != null)
        {
            leftVector = leftObject.transform.position - transform.position;
        }
        if (upObject != null)
        {
            upVector = upObject.transform.position - transform.position;
        }
        if (downObject != null)
        {
            downVector = downObject.transform.position - transform.position;
        }
    }
   
    private void SearchClosestItemsOfSelectedPiece()
    {
        if (upObject != null)
        {
            if (!connectedToUp)
            {
                RaycastHit2D upRay = Physics2D.Raycast(new Vector2(transform.position.x, (transform.position.y + boxCollider2D.size.y / 2) + 0.2f), Vector2.up, 1f);
                Debug.DrawRay(new Vector2(transform.position.x, (transform.position.y + boxCollider2D.size.y / 2) + 0.2f), Vector2.up);
                if (upRay.collider != null)
                {

                    if (upRay.collider.gameObject == upObject)
                    {
                        if (upRay.distance < 0.05f)
                        {
                            canConncectToUp = true;
                        }
                        else
                        {
                            canConncectToUp = false;
                        }
                    }
                }
                if (upRay.collider == null)
                {
                    canConncectToUp = false;
                }
            }
        }
        if (downObject != null)
        {
            if (!connectedToDown)
            {
                RaycastHit2D downRay = Physics2D.Raycast(new Vector2(transform.position.x, (transform.position.y - boxCollider2D.size.y / 2) - 0.2f), Vector2.down, 1f);
                Debug.DrawRay(new Vector2(transform.position.x, (transform.position.y - boxCollider2D.size.y / 2) - 0.2f), Vector2.down);
                if (downRay.collider != null)
                    if (downRay.collider != null)
                    {
                        if (downRay.collider.gameObject == downObject)
                        {
                            if (downRay.distance < 0.05f)
                            {
                                canConnectToDown = true;
                            }
                            else
                            {
                                canConnectToDown = false;
                            }
                        }
                    }
                if (downRay.collider == null)
                {
                    canConnectToDown = false;
                }

            }

        }


        if (rightObject != null)
        {
            if (!connectedToRight)
            {
                RaycastHit2D rightRay = Physics2D.Raycast(new Vector2(transform.position.x + boxCollider2D.size.x / 2 + 0.2f, transform.position.y), Vector2.right, 1f);
                Debug.DrawRay(new Vector2(transform.position.x + boxCollider2D.size.x / 2 + 0.2f, transform.position.y), Vector2.right);

                if (rightRay.collider != null)
                {
                    if (rightRay.collider.gameObject == rightObject)
                    {
                        if (rightRay.distance < 0.05f)
                        {
                            canConnectToRight = true;
                        }
                        else
                        {
                            canConnectToRight = false;
                        }
                    }
                }
                if (rightRay.collider == null)
                {
                    canConnectToRight = false;
                }

            }

        }
        if (leftObject != null)
        {
            if (!connectedToLeft)
            {

                RaycastHit2D leftRay = Physics2D.Raycast(new Vector2((transform.position.x - boxCollider2D.size.x / 2) - 0.2f, transform.position.y), Vector2.left, 1f);
                Debug.DrawRay(new Vector2((transform.position.x - boxCollider2D.size.x / 2) - 0.2f, transform.position.y), Vector2.left);
                if (leftRay.collider != null)
                {

                    if (leftRay.collider.gameObject == leftObject)
                    {
                        if (leftRay.distance < 0.05f)
                        {
                            canConnectToLeft = true;
                        }
                        else
                        {
                            canConnectToLeft = false;
                        }
                    }
                }
                if (leftRay.collider == null)
                {
                    canConnectToLeft = false;
                }
            }
        }

    }

    private void SearchClosestItemsOfConnectedObjects()
    {
        foreach (GameObject puzzlePiece in ConnectedObjects)
        {
            if (puzzlePiece != null)
            {
                BoxCollider2D boxCollider = puzzlePiece.GetComponent<BoxCollider2D>() as BoxCollider2D;

                if (puzzlePiece.GetComponent<PiecesScript>().upObject != null)
                {
                    if (!puzzlePiece.GetComponent<PiecesScript>().connectedToUp)
                    {
                        RaycastHit2D[] upRays = Physics2D.RaycastAll(new Vector2(puzzlePiece.transform.position.x, (puzzlePiece.transform.position.y + boxCollider.size.y / 2) + 0.2f), Vector2.up, 1f);
                        Debug.DrawRay(new Vector2(puzzlePiece.transform.position.x, (puzzlePiece.transform.position.y + boxCollider.size.y / 2) + 0.2f), Vector2.up);

                        foreach (RaycastHit2D upRay in upRays)
                        {
                            if (upRay.collider != null)
                            {

                                if (upRay.collider.gameObject == puzzlePiece.GetComponent<PiecesScript>().upObject)
                                {
                                    if (upRay.distance < 0.05f)
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConncectToUp = true;
                                    }
                                    else
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConncectToUp = false;
                                    }
                                }
                            }
                            if (upRay.collider == null)
                            {
                                puzzlePiece.GetComponent<PiecesScript>().canConncectToUp = false;
                            }
                        }

                    }
                }
                if (puzzlePiece.GetComponent<PiecesScript>().downObject != null)
                {
                    if (!puzzlePiece.GetComponent<PiecesScript>().connectedToDown)
                    {
                        RaycastHit2D[] downRays = Physics2D.RaycastAll(new Vector2(puzzlePiece.transform.position.x, (puzzlePiece.transform.position.y - boxCollider.size.y / 2) - 0.2f), Vector2.down, 1f);
                        Debug.DrawRay(new Vector2(puzzlePiece.transform.position.x, (puzzlePiece.transform.position.y - boxCollider.size.y / 2) - 0.2f), Vector2.down);
                        foreach (RaycastHit2D downRay in downRays)
                        {
                            if (downRay.collider != null)
                            {
                                if (downRay.collider.gameObject == puzzlePiece.GetComponent<PiecesScript>().downObject)
                                {
                                    if (downRay.distance < 0.05f)
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConnectToDown = true;
                                    }
                                    else
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConnectToDown = false;
                                    }
                                }
                            }
                            if (downRay.collider == null)
                            {
                                puzzlePiece.GetComponent<PiecesScript>().canConnectToDown = false;
                            }
                        }


                    }

                }

                if (puzzlePiece.GetComponent<PiecesScript>().rightObject != null)
                {
                    if (!puzzlePiece.GetComponent<PiecesScript>().connectedToRight)
                    {
                        RaycastHit2D[] rightRays = Physics2D.RaycastAll(new Vector2(puzzlePiece.transform.position.x + boxCollider.size.x / 2 + 0.2f, puzzlePiece.transform.position.y), Vector2.right, 1f);
                        Debug.DrawRay(new Vector2(puzzlePiece.transform.position.x + boxCollider.size.x / 2 + 0.2f, puzzlePiece.transform.position.y), Vector2.right);

                        foreach (RaycastHit2D rightRay in rightRays)
                        {
                            if (rightRay.collider != null)
                            {
                                if (rightRay.collider.gameObject == puzzlePiece.GetComponent<PiecesScript>().rightObject)
                                {
                                    if (rightRay.distance < 0.05f)
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConnectToRight = true;
                                    }
                                    else
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConnectToRight = false;
                                    }
                                }
                            }
                            if (rightRay.collider == null)
                            {
                                puzzlePiece.GetComponent<PiecesScript>().canConnectToRight = false;
                            }
                        }
                    }

                }
                if (puzzlePiece.GetComponent<PiecesScript>().leftObject != null)
                {
                    if (!puzzlePiece.GetComponent<PiecesScript>().connectedToLeft)
                    {
                        RaycastHit2D[] leftRays = Physics2D.RaycastAll(new Vector2((puzzlePiece.transform.position.x - boxCollider.size.x / 2) - 0.2f, puzzlePiece.transform.position.y), Vector2.left, 1f);
                        Debug.DrawRay(new Vector2((puzzlePiece.transform.position.x - boxCollider.size.x / 2) - 0.2f, puzzlePiece.transform.position.y), Vector2.left);
                        foreach (RaycastHit2D leftRay in leftRays)
                        {
                            if (leftRay.collider != null)
                            {

                                if (leftRay.collider.gameObject == puzzlePiece.GetComponent<PiecesScript>().leftObject)
                                {
                                    if (leftRay.distance < 0.05f)
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConnectToLeft = true;
                                    }
                                    else
                                    {
                                        puzzlePiece.GetComponent<PiecesScript>().canConnectToLeft = false;
                                    }
                                }
                            }
                            if (leftRay.collider == null)
                            {
                                puzzlePiece.GetComponent<PiecesScript>().canConnectToLeft = false;
                            }
                        }

                    }
                }

            }
        }
    }
    private void AssembleThePieces()
    {

        #region Right
        
        if (connectedToRight == false)
        {
            if (DragAndDrop.Instance.AllowingToConnect() && canConnectToRight)
            {
                transform.position = rightObject.transform.position - (Vector3)rightVector;
                StartCoroutine(ConnectRightSituations());
            }
        }
        #endregion Right
        #region Left
        
        if (connectedToLeft == false)
        {
            if (DragAndDrop.Instance.AllowingToConnect() && canConnectToLeft)
            {
                transform.position = leftObject.transform.position - (Vector3)leftVector;
                StartCoroutine(ConnectLeftSituations());
            }
        }
        #endregion Left
        #region Up
       
        if (connectedToUp == false)
        {

            if (DragAndDrop.Instance.AllowingToConnect() && canConncectToUp)
            {
                transform.position = upObject.transform.position - (Vector3)upVector;
                StartCoroutine(ConnectUpSituations());
            }


        }
        #endregion Up
        #region Down
       
        if (connectedToDown == false)
        {
            if (DragAndDrop.Instance.AllowingToConnect() && canConnectToDown)
            {
                transform.position = downObject.transform.position - (Vector3)downVector;
                StartCoroutine(ConnectDownSituations());
            }

        }
        #endregion Down

        foreach (GameObject puzzleObject in GetComponent<PiecesScript>().ConnectedObjects.ToArray())
        {
            foreach (GameObject childObject in puzzleObject.GetComponent<PiecesScript>().ConnectedObjects.ToArray())
            {
                if (childObject != null)
                {
                    if (!GetComponent<PiecesScript>().ConnectedObjects.Contains(childObject))
                    {
                        GetComponent<PiecesScript>().ConnectedObjects.Add(childObject);
                    }
                }
            }
        }


        FixingPositions();
        FixPositions();
    }
  

    private void SetConnectedObjects()
    {
        foreach(GameObject puzzlePiece in PuzzlePieceList.Instance.AllObjects)
        {
            if(puzzlePiece.GetComponent<PiecesScript>().upObject != null)
            {
                if (puzzlePiece.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzlePiece.GetComponent<PiecesScript>().upObject))
                {
                    puzzlePiece.GetComponent<PiecesScript>().connectedToUp = true;
                }
            }
            if (puzzlePiece.GetComponent<PiecesScript>().downObject != null)
            {
                if (puzzlePiece.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzlePiece.GetComponent<PiecesScript>().downObject))
                {
                    puzzlePiece.GetComponent<PiecesScript>().connectedToDown = true;
                }
            }
            if (puzzlePiece.GetComponent<PiecesScript>().rightObject != null)
            {
                if (puzzlePiece.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzlePiece.GetComponent<PiecesScript>().rightObject))
                {
                    puzzlePiece.GetComponent<PiecesScript>().connectedToRight = true;
                }
            }
            if (puzzlePiece.GetComponent<PiecesScript>().leftObject != null)
            {
                if (puzzlePiece.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzlePiece.GetComponent<PiecesScript>().leftObject))
                {
                    puzzlePiece.GetComponent<PiecesScript>().connectedToLeft = true;
                }
            }
        }
    }
    private IEnumerator ConnectRightSituations()
    {
        if (!ConnectedObjects.Contains(rightObject))
        {
            ConnectedObjects.Add(rightObject);
        }
        if (!rightObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(this.gameObject))
        {
            rightObject.GetComponent<PiecesScript>().ConnectedObjects.Add(this.gameObject);
        }

        foreach (GameObject puzzleObject in rightObject.GetComponent<PiecesScript>().ConnectedObjects)
        {
            if (!ConnectedObjects.Contains(puzzleObject))
            {
                ConnectedObjects.Add(puzzleObject);
            }
        }
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject puzzleObject in ConnectedObjects)
        {
            if (!rightObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzleObject))
            {

                rightObject.GetComponent<PiecesScript>().ConnectedObjects.Add(puzzleObject);
            }
        }
      
       
        connectedToRight = true;
    }
    private IEnumerator ConnectLeftSituations()
    {
        if (!ConnectedObjects.Contains(leftObject))
        {
            ConnectedObjects.Add(leftObject);
        }
        if (!leftObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(this.gameObject))
        {
            leftObject.GetComponent<PiecesScript>().ConnectedObjects.Add(this.gameObject);
        }

        foreach (GameObject puzzleObject in leftObject.GetComponent<PiecesScript>().ConnectedObjects)
        {
            if (!ConnectedObjects.Contains(puzzleObject))
            {
                ConnectedObjects.Add(puzzleObject);
            }
        }
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject puzzleObject in ConnectedObjects)
        {
            if (!leftObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzleObject))
            {
                leftObject.GetComponent<PiecesScript>().ConnectedObjects.Add(puzzleObject);
            }
        }
       
        
        connectedToLeft = true;


    }
    private IEnumerator ConnectUpSituations()
    {
        if (!ConnectedObjects.Contains(upObject))
        {
            ConnectedObjects.Add(upObject);
        }
        if (!upObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(this.gameObject))
        {
            upObject.GetComponent<PiecesScript>().ConnectedObjects.Add(this.gameObject);
        }


        foreach (GameObject puzzleObject in upObject.GetComponent<PiecesScript>().ConnectedObjects)
        {
            if (!ConnectedObjects.Contains(puzzleObject))
            {
                ConnectedObjects.Add(puzzleObject);
            }
        }
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject puzzleObject in ConnectedObjects)
        {
            if (!upObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzleObject))
            {
                upObject.GetComponent<PiecesScript>().ConnectedObjects.Add(puzzleObject);
            }
        }
      
        connectedToUp = true;

    }
    private IEnumerator ConnectDownSituations()
    {

        if (!ConnectedObjects.Contains(downObject))
        {
            ConnectedObjects.Add(downObject);
        }
        if (!downObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(this.gameObject))
        {
            downObject.GetComponent<PiecesScript>().ConnectedObjects.Add(this.gameObject);
        }

        foreach (GameObject puzzleObject in downObject.GetComponent<PiecesScript>().ConnectedObjects)
        {

            if (!ConnectedObjects.Contains(puzzleObject))
            {
                ConnectedObjects.Add(puzzleObject);
            }

        }
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject puzzleObject in ConnectedObjects)
        {
            if (!downObject.GetComponent<PiecesScript>().ConnectedObjects.Contains(puzzleObject))
            {
                downObject.GetComponent<PiecesScript>().ConnectedObjects.Add(puzzleObject);
            }

        }
     
        
        connectedToDown = true;

    }


    private bool IsClosestGameObjectsFull()
    {
        bool isFull = false;

        foreach(GameObject closestObjects in ClosestGameObjects)
        {
            if (ConnectedObjects.Contains(closestObjects))
            {
                isFull = true;
            }
            else
            {
                isFull = false;
            }
        }
        return isFull;
    }
    private bool IsSelectedPieceLooking()
    {
        bool isSelectedLooking = false;

        if (selected)
        {
            if(DragAndDrop.Instance.GetSelectedPiece().GetComponent<PiecesScript>().canConncectToUp ||
                DragAndDrop.Instance.GetSelectedPiece().GetComponent<PiecesScript>().canConnectToDown ||
                DragAndDrop.Instance.GetSelectedPiece().GetComponent<PiecesScript>().canConnectToLeft ||
                DragAndDrop.Instance.GetSelectedPiece().GetComponent<PiecesScript>().canConnectToRight)
            {
                isSelectedLooking = true;
            }
            else
            {
                isSelectedLooking = false;
            }
        }
        return isSelectedLooking;
    }
    private void FixingPositions()
    {
        foreach(GameObject puzzlePiece in ConnectedObjects)
        {
            if(puzzlePiece != null)
            {
                if (puzzlePiece.GetComponent<PiecesScript>().rightObject == this.gameObject)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().rightObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().rightVector;

                }
                else if (puzzlePiece.GetComponent<PiecesScript>().leftObject == this.gameObject)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().leftObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().leftVector;
                }
                else if (puzzlePiece.GetComponent<PiecesScript>().upObject == this.gameObject)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().upObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().upVector;
                }
                else if (puzzlePiece.GetComponent<PiecesScript>().downObject == this.gameObject)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().downObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().downVector;
                }
            }
           
        }
    }

    private void FixPositions()
    {
        foreach(GameObject puzzlePiece in PuzzlePieceList.Instance.AllObjects)
        {
            if(puzzlePiece != null)
            {
                if (puzzlePiece.GetComponent<PiecesScript>().connectedToRight)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().rightObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().rightVector;
                }
                else if (puzzlePiece.GetComponent<PiecesScript>().connectedToLeft)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().leftObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().leftVector;
                }
                else if (puzzlePiece.GetComponent<PiecesScript>().connectedToDown)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().downObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().downVector;
                }
                else if (puzzlePiece.GetComponent<PiecesScript>().connectedToUp)
                {
                    puzzlePiece.transform.position = puzzlePiece.GetComponent<PiecesScript>().upObject.transform.position -
                                                     (Vector3)puzzlePiece.GetComponent<PiecesScript>().upVector;
                }
            }
        }
    }
    public void WinCondition()
    {
        if (ConnectedObjects.Count >= 9)
        {
            PuzzleManager.Instance.isLevelPassed = true;
            DragAndDrop.Instance.allowToPuzzle = false;
        }
     
    }


    private void Shuffling()
    {
        DragAndDrop.Instance.allowToPuzzle = false;
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        LeanTween.moveLocal(gameObject, randomPos, 0.5f);
    }
    private void CancelShuffling()
    {
        CancelInvoke();
        isShufflingDone = true;
        DragAndDrop.Instance.allowToPuzzle = true;
    }



}

