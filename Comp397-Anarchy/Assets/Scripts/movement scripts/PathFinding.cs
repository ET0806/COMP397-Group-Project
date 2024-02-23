using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class Pathfinding : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;

    private Node[,] grid;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        // Implementation of grid creation, initialization, and node connections
        // ...

    }

    public void UpdateGrid()
    {
        // Update grid if necessary (e.g., if obstacles are moving)
        // ...
    }

    public List<Vector2Int> FindPath(Vector3 startPos, Vector3 targetPos)
    {
        // Implementation of the A* algorithm to find the shortest path
        // ...

        return null; // Return null if no path is found
    }
}