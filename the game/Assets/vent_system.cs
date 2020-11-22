using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vent_system : MonoBehaviour
{
    public Vent[] vents;
    public int currentVent;
    public bool inVent;

    PlayerManager player;

    public void enterVent(PlayerManager p, Vent vent) {
        p.body.SetActive(false);
        p.gameObject.GetComponent<PlayerMovement>().enabled = false;
        inVent = true;
        player = p;

        for (int i = 0; i < vents.Length; i++)
        {
            if(vent = vents[i])
            {
                currentVent = i - 1;
            }
        }
    }

    private void Update()
    {
        if (currentVent > vents.Length - 1)
        {
            currentVent = 0;
        }
        if (currentVent < 0)
        {
            currentVent = vents.Length - 1;
        }


        if (inVent) {
            player.gameObject.transform.position = vents[currentVent].exit.position;
            if(Input.GetKeyDown(KeyCode.A)) {
                currentVent--;
                player.body.transform.rotation = vents[currentVent].transform.rotation;
            }
            if(Input.GetKeyDown(KeyCode.D)) {
                currentVent++;
                player.body.transform.rotation = vents[currentVent].transform.rotation;
            }


            if(Input.GetKeyDown(KeyCode.Space)) {
                ExitVent();
            }

        }
    }

    private void ExitVent()
    {
        player.body.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        inVent = false;
    }
}
