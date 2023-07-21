using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawGameManager : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private GameObject square1;
    [SerializeField] private GameObject square2;
    [SerializeField] private GameObject square3;

    private GameObject selectedPiece;

    private float xDistance;
    private float yDistance;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (ray.collider == null) { return; }

            if (ray.transform.CompareTag("puzzle"))
            {
                selectedPiece = ray.transform.gameObject;
                
            }
        }
        if (selectedPiece != null)
        {


           

            /*Distance = square2.transform.position.x  - selectedPiece.transform.position.x;
            Vector2 square2Vector = square2.transform.position;
            square2Vector.y = selectedPiece.transform.position.y;
            square2Vector.x = ((square2Vector.x - selectedPiece.transform.position.x) / xDistance) +selectedPiece.transform.position.x; //* distance; //+ selectedPiece.transform.position.x;
            square2.transform.position = square2Vector;

            yDistance = square3.transform.position.y - selectedPiece.transform.position.y;
            Vector2 square3Vector = square3.transform.position;
            square3Vector.x = selectedPiece.transform.position.x;
            square3Vector.y = (square3Vector.y - selectedPiece.transform.position.y) / yDistance + selectedPiece.transform.position.y;
            square3.transform.position = square3Vector;*/
        }
        else { selectedPiece = null; }


        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {

                selectedPiece = null;

            }


        }
    }
}
