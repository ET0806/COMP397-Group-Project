using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Player or target landmark
    public float speed = 5f;

    private Pathfinding pathfinding;

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        if (pathfinding == null)
        {
            Debug.LogError("Pathfinding component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Update the pathfinding grid and find path to the target
        pathfinding.UpdateGrid();
        List<Vector2Int> path = pathfinding.FindPath(transform.position, target.position);

        if (path != null && path.Count > 0)
        {
            // Move towards the next point in the path
            Vector3 nextWaypoint = new Vector3(path[0].x + 0.5f, 0, path[0].y + 0.5f);
            transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, speed * Time.deltaTime);

            // Rotate towards the next waypoint
            transform.LookAt(nextWaypoint);
        }
    }
}