using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DrawMeshFull : MonoBehaviour {

    public static DrawMeshFull Instance { get; private set; }

    LevelManager2 levelManager2;
   
    public GameObject Brush;
    public GameObject BrushColor;
    public Color brushColor;
    public GameObject Eraser;
    private GameObject paint;
    public Material drawMeshMaterial;
    public List<GameObject> AllGameObjects;
    public GameObject lastGameObject;
    private int lastSortingOrder;
    private Mesh mesh;
    private Vector3 lastMouseWorldPosition;
    private float lineThickness = 1f;
    private Color lineColor = Color.black;

    [SerializeField] private float VerticalSetting;
    [SerializeField] private float HorizontalSetting;

    public int index = 0;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    private void Awake()
    {
        Instance = this;

    }
    private void OnEnable()
    {
        
    }
    void Start()
    {
        levelManager2 = FindObjectOfType<LevelManager2>();
        SetColor(GetColorFromString("010203")); SetColorAlpha(1f);
        BrushColor.gameObject.SetActive(true);
        Brush.gameObject.SetActive(true);
        BrushColor.gameObject.GetComponent<SpriteRenderer>().color = brushColor;
        Eraser.gameObject.SetActive(false);
       
    }
    
    private void Update() {

        brushColor.a = 1f;
        
        BrushColor.gameObject.GetComponent<SpriteRenderer>().color = brushColor;
       

        if (!IsPointerOverUI())
        {
            // Only run logic if not over UI
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            
            if (Input.GetMouseButtonDown(0) && levelManager2.canDraw)
            {
                // Mouse Down
                CreateMeshObject();
                mesh = MeshUtils.CreateMesh(mouseWorldPosition, mouseWorldPosition, mouseWorldPosition, mouseWorldPosition);
                mesh.MarkDynamic();
                lastGameObject.GetComponent<MeshFilter>().mesh = mesh;
                Material material = new Material(drawMeshMaterial);
                material.color = lineColor;
                
                lastGameObject.GetComponent<MeshRenderer>().material = material;
            }

            if (levelManager2.canDraw)
            {
                
                if (mouseWorldPosition.x < maxX && mouseWorldPosition.x > minX && mouseWorldPosition.y < maxY && mouseWorldPosition.y > minY)
                {

                    
                    Cursor.visible = false;
                    BrushColor.transform.position = GetMouseWorldPosition() + new Vector3(HorizontalSetting, VerticalSetting, 0f);
                    Eraser.transform.position = GetMouseWorldPosition() + new Vector3(HorizontalSetting, VerticalSetting, 0f);
                    if (Input.GetMouseButton(0))
                    {
                        // Mouse Held Down
                        float minDistance = .1f;
                        if (Vector2.Distance(lastMouseWorldPosition, mouseWorldPosition) > minDistance)
                        {
                            // Far enough from last point
                            Vector2 forwardVector = (mouseWorldPosition - lastMouseWorldPosition).normalized;

                            lastMouseWorldPosition = mouseWorldPosition;

                            MeshUtils.AddLinePoint(mesh, mouseWorldPosition, lineThickness);

                        }
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        // Mouse Up
                        MeshUtils.AddLinePoint(mesh, mouseWorldPosition, 0f);
                    }
                }
                else
                {
                   Cursor.visible = true;
                }
            }
            else
            {
                Cursor.visible = true;
            }
            
        }
        
        
    }

    private void CreateMeshObject() {
        lastGameObject = new GameObject("DrawMeshSingle", typeof(MeshFilter), typeof(MeshRenderer),typeof(MeshCollider));
        
        AllGameObjects.Add(lastGameObject);
        index++;
        lastSortingOrder++;
        lastGameObject.GetComponent<MeshRenderer>().sortingOrder = lastSortingOrder;
        Color color = lastGameObject.GetComponent<MeshRenderer>().material.color;
        color.a = 0.1f;
        lastGameObject.GetComponent<MeshRenderer>().material.color = color;
       
    }

    public void SetThickness(float lineThickness) {
        this.lineThickness = lineThickness;
        
    }

    public void SetColor(Color lineColor) {
        this.lineColor = lineColor;
        
    }
    public void SetColorAlpha(float alphaRate)
    {
        this.lineColor.a = alphaRate;
    }

    // Returns 00-FF, value 0->255
    public string Dec_to_Hex(int value)
    {
        return value.ToString("X2");
    }

    // Returns 0-255
    public int Hex_to_Dec(string hex)
    {
        return Convert.ToInt32(hex, 16);
    }

    // Returns a hex string based on a number between 0->1
    public string Dec01_to_Hex(float value)
    {
        return Dec_to_Hex((int)Mathf.Round(value * 255f));
    }

    // Returns a float between 0->1
    public float Hex_to_Dec01(string hex)
    {
        return Hex_to_Dec(hex) / 255f;
    }

    // Get Hex Color FF00FF
    public string GetStringFromColor(Color color)
    {
        string red = Dec01_to_Hex(color.r);
        string green = Dec01_to_Hex(color.g);
        string blue = Dec01_to_Hex(color.b);
        return red + green + blue;
    }

    // Get Hex Color FF00FFAA
    public string GetStringFromColorWithAlpha(Color color)
    {
        string alpha = Dec01_to_Hex(color.a);
        return GetStringFromColor(color) + alpha;
    }

    // Sets out values to Hex String 'FF'
    public void GetStringFromColor(Color color, out string red, out string green, out string blue, out string alpha)
    {
        red = Dec01_to_Hex(color.r);
        green = Dec01_to_Hex(color.g);
        blue = Dec01_to_Hex(color.b);
        alpha = Dec01_to_Hex(color.a);
    }

    // Get Hex Color FF00FF
    public string GetStringFromColor(float r, float g, float b)
    {
        string red = Dec01_to_Hex(r);
        string green = Dec01_to_Hex(g);
        string blue = Dec01_to_Hex(b);
        return red + green + blue;
    }

    // Get Hex Color FF00FFAA
    public string GetStringFromColor(float r, float g, float b, float a)
    {
        string alpha = Dec01_to_Hex(a);
        return GetStringFromColor(r, g, b) + alpha;
    }

    // Get Color from Hex string FF00FFAA
    public Color GetColorFromString(string color)
    {
        float red = Hex_to_Dec01(color.Substring(0, 2));
        float green = Hex_to_Dec01(color.Substring(2, 2));
        float blue = Hex_to_Dec01(color.Substring(4, 2));
        float alpha = 1f;
        if (color.Length >= 8)
        {
            // Color string contains alpha
            alpha = Hex_to_Dec01(color.Substring(6, 2));
        }
        return new Color(red, green, blue, alpha);
    }
    public Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    public bool IsPointerOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
        {
            PointerEventData pe = new PointerEventData(EventSystem.current);
            pe.position = Input.mousePosition;
            List<RaycastResult> hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pe, hits);
            return hits.Count > 0;
        }
    }


}