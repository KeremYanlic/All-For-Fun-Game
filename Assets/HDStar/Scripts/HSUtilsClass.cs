using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HSUtilsClass 
{
    public static Vector3 GenerateRandomPosition(float minX, float maxX, float minY, float maxY)
    {
        return new Vector3(Random.Range(minX, maxX) + 0.1f, Random.Range(minY, maxY) + 0.1f, 10f);
    }
    public static Vector2 GenerateRandomPositionWithCanvas()
    {
        return new Vector3(Random.Range(-1f, 1f) * Screen.width / 2, Random.Range(-1f, 1f) * Screen.height / 2, 10f);
    }
    public static float GenerateRandomRotationZValue(float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    public static Color FullOpacity(float r, float g, float b, float alpha)
    {
        return new Color(r, g, b, alpha);
    }

    public static void FullOpacity(GameObject gameObject, SpriteRenderer spriteRenderer, Color color)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }

    public static Vector3 GetWorldMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
}
