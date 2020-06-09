using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Route currRoute;
    //[SerializeField]public int goal;

    public bool isMoving = false;
    // Update is called once per frame

    int stepCounter = 1;
    void Update()
    {
        //if (!isMoving)
        //{
        //StartCoroutine(Move(7));
        //StartCoroutine(moveToConnection());//if connection exists we move, otherwise we break
        //}
    }

    public IEnumerator Move(int goal)
    {
        Debug.Log("isMoving: " + isMoving);
        //To Stop this from being called before it is complete use either isMoving or have a reference to this (current) coroutine at class level so you can check if this is invoked
        if (!isMoving)
        {
         isMoving = true;
        /*Transform[] r = new Transform[currRoute.children.Length - 1];
        Array.Copy(currRoute.children, 1, r, 0, r.Length - 1);
          foreach (Transform childPos in r)
        {
            yield return StartCoroutine(MoveInSteps(childPos.position));
        }*/
        
            //stepCounter = 1;
            while (goal > 0)
            {
                Vector3 goalPosition = currRoute.children[stepCounter].position;
                //StartCoroutine(MoveInSteps(goalPosition));
                while (transform.position != goalPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goalPosition, Time.deltaTime);
                    yield return null;
                }
                Debug.Log("Moved guy to: " + transform.position + " Goal is : " + goalPosition + ", Step is: " + stepCounter);
                stepCounter++;
                goal--;

            }
            isMoving = false;
            StartCoroutine(moveToConnection());
        }
        else
        {
            yield break;
        }
    }

    public IEnumerator moveToConnection()
    {
        Debug.Log("MoveToConnection : isMoving : " + isMoving + ", step counter: " + stepCounter + " Connection contains key: " + currRoute.connections.ContainsKey(stepCounter));
        if ((!isMoving && currRoute.connections.ContainsKey(stepCounter - 1)))
        {
            Debug.Log("Reached some connection!");
            isMoving = true;
            Vector3 goalPosition = currRoute.children[currRoute.connections[stepCounter - 1]].position;
            while (transform.position != goalPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, goalPosition, Time.deltaTime);
                yield return null;
            }

            stepCounter = currRoute.connections[stepCounter - 1];
            isMoving = false;
        }
        else
        {
            yield break;
        }
    }
}
