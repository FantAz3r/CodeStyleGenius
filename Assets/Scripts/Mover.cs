using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform waypointsParent;

    private float _distanseError = 0.01f;
    private Transform[] waypoints;
    private int currentWaypointIndex;

    private void Start()
    {
        waypoints = new Transform[waypointsParent.childCount];

        for (int i = 0; i < waypointsParent.childCount; i++)
        {
            waypoints[i] = waypointsParent.GetChild(i);
        }
    }

    private void Update()
    {
        MoveTowards();
    }

    private void MoveTowards()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - targetWaypoint.position) < _distanseError)
        {
            UpdateWaypoint(); 
        }
    }

    private void UpdateWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        Vector3 nextWaypointPosition = waypoints[currentWaypointIndex].position;
        transform.forward = nextWaypointPosition - transform.position;
    }
}
