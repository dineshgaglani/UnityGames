using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameController : MonoBehaviour
{
    public Players players;
    // Start is called before the first frame update

    int currPlayerNum;

    private void Start()
    {
        currPlayerNum = 0;
    }

    private void OnMouseUp()
    {
        Character currPlayer = players.players[currPlayerNum % players.players.Length];

        int places = new System.Random().Next(1, 6);
        switchDice(places);

        StartCoroutine(currPlayer.Move(places));
        StartCoroutine(currPlayer.moveToConnection());

        currPlayerNum++;
    }


    void switchDice(int target)
    {
        //Switch material
        String targetFileName = "Materials/" + target + "_dots";
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material materialToChange = meshRenderer.material;
        Material randomMaterial = Resources.Load(targetFileName, typeof(Material)) as Material;
        materialToChange = randomMaterial;
        meshRenderer.material = materialToChange;
    }

    IEnumerator switchDiceContinuosly(int random)
    {
        switchDice(random);
        yield return new WaitForSeconds(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            int randomInt = new System.Random().Next(1, 6);
            StartCoroutine(switchDiceContinuosly(randomInt));
            //Debug.Log("Mouse Down!!");
        }
    }
}
