using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public Character[] players;

    private void Awake()
    {
        players = gameObject.GetComponentsInChildren<Character>();
    }
}
