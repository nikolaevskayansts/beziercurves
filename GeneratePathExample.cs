using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace PathCreation.Examples {
    // Example of creating a path at runtime from a set of points.

    [RequireComponent(typeof(PathCreator))]
    public class GeneratePathExample : MonoBehaviour {

        public bool closedLoop = true;
        public List<Transform> waypoints = new List<Transform>();
        public float minOffset = -5, maxOffset = 5;
        public GameObject waypointPref;
        public int waypointsCount;

        void Start () 
        {
            // waypoints = GetComponentsInChildren<Transform>();

            for (int i = 1; i < waypointsCount; i++)
            {
                Vector3 randPos = new Vector3(Random.Range(minOffset, maxOffset), Random.Range(minOffset, maxOffset), Random.Range(minOffset, maxOffset));
                GameObject waypoint = Instantiate(waypointPref, randPos, Quaternion.identity);
                waypoints.Add(waypoint.transform);
                waypoint.transform.parent = transform;
            }

            BezierPath bezierPath = new BezierPath (waypoints, closedLoop, PathSpace.xyz);
            GetComponent<PathCreator> ().bezierPath = bezierPath;
            

        }

        public void SetWaypointsCount()
        {

        }
    }
}