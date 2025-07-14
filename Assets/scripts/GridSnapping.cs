using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridSnapping
{
    public static float cellSize = 1f; // размер клетки

    public static void PlaceToNearestCell(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        float x = Mathf.Round(pos.x / cellSize) * cellSize;
        float y = Mathf.Round(pos.y / cellSize) * cellSize;
        float z = Mathf.Round(pos.z / cellSize) * cellSize;

        obj.transform.position = new Vector3(x, y, z);
    }
}