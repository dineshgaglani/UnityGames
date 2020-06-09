using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] children;
    public Dictionary<int, int> connections;

    private void Awake()
    {
        children = gameObject.GetComponentsInChildren<Transform>();
        connections = new Dictionary<int, int>();
        //TODO - Randomly set-up connections 
        //Logic - Create 14 UNIQUE random nums between 1 and sizeOf(children) and another 14 UNIQUE each less than the first 14. Set-up 14 pairs, 7 of which have the bigger number in the key (snakes), 7 of which have the smaller as the key (ladders)
        connections.Add(7, 18);
        connections.Add(15, 3);
        connections.Add(14, 2);
        connections.Add(13, 5);



        foreach (int start in connections.Keys)
        {
            if (start < connections[start])
            {
                //It's a LADDER
                Debug.Log("Drawing from: " + start + " to " + connections[start]);
                Debug.DrawLine(children[start].position, children[connections[start]].position, Color.white);
            }
            else
            {
                //It's a SNAKE
                Debug.DrawLine(children[start].position, children[connections[start]].position, Color.blue);
            }
        }
    }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.green;
       for (int i = 0; i < children.Length - 1; i++)
       {
            Gizmos.DrawLine(children[i].position, children[i+1].position);
       }

    }
}
