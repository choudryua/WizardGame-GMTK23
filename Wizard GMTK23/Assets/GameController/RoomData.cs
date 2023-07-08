using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public int curRouteListIndex;
    public Vector2 currentPlayerGoal;
    public List<Vector2> curRoutePosVector = new List<Vector2>();
    public Transform[] routeAPos;
    public List<Vector2> routeAPosVector = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
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
