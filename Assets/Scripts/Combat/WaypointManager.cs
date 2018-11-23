using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    private Waypoint[] waypointList;

    void Awake()
    {
        waypointList = GetComponentsInChildren<Waypoint>();         //Get all waypoint children
        SortWaypoints(waypointList, 0, (waypointList.Length - 1));  //Sort them by their waypoint numbers

        for(int i = 0; i < waypointList.Length; i++)        //Set up previous and next variables in each waypoint
        {
            if (i == 0)
            {
                waypointList[i].Previous = waypointList[(waypointList.Length - 1)];
                waypointList[i].Next = waypointList[i + 1];
            }
            else if (i == (waypointList.Length - 1))
            {
                waypointList[i].Previous = waypointList[i - 1];
                waypointList[i].Next = waypointList[0] ;
            }
            else
            {
                waypointList[i].Previous = waypointList[i - 1];
                waypointList[i].Next = waypointList[i + 1];
            }
        }
    }
	
	void Update () {
		
	}

    void SortWaypoints(Waypoint[] waypointList, int low, int high)
    {
        if(low < high)
        {
            int pi = Partition(waypointList, low, high);
            SortWaypoints(waypointList, low, pi - 1);
            SortWaypoints(waypointList, pi + 1, high);
        }
    }

    int Partition(Waypoint[] waypointList, int low, int high)
    {
        int pivot = waypointList[high].waypointNumber;
        int index = low - 1;

        for(int j = low; j <= (high - 1); j++)
        {
            if(waypointList[j].waypointNumber <= pivot)
            {
                index++;
                Swap<Waypoint>(ref waypointList[index], ref waypointList[j]);
            }
        }

        Swap<Waypoint>(ref waypointList[index + 1], ref waypointList[high]);

        return (index + 1);
    }

    void Swap<T> (ref T val1, ref T val2)
    {
        T temp = val1;
        val1 = val2;
        val2 = temp;
    }
}
