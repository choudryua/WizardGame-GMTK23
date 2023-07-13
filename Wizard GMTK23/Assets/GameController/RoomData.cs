using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public int curRouteListIndex;
    public Vector2 currentPlayerGoal;
    public List<Vector2> curRoutePosVector = new List<Vector2>();
    public Transform[] routeAPos;
    public List<Vector2> routeAPosVector = new List<Vector2>();
    public GameObject objSpawnPoint;
    public Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(objSpawnPoint.transform.position.x, objSpawnPoint.transform.position.y);
        foreach(Transform x in routeAPos)
        {
            float tmpX = x.position.x;
            float tmpY = x.position.y;
            routeAPosVector.Add(new Vector2(tmpX, tmpY));
        }
        updateRoute(routeAPosVector);
        curRouteListIndex = 0;
        updateCurGoal(curRouteListIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateRoute(List<Vector2> newRoute)
    {
        curRoutePosVector.Clear();
        curRoutePosVector.AddRange(newRoute);
    }
    public void updateCurGoal(int x)
    {
        currentPlayerGoal = curRoutePosVector[x];
        curRouteListIndex = x;
    }
}
