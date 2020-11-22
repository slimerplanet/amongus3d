using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Vent : MonoBehaviour
{

    public vent_system system;
    public Transform exit;

    bool onVent;

    PlayerManager player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("localplayer"))
        {
            onVent = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("localplayer"))
        {
            onVent = false;
        }
    }

    private void Update()
    {

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("localplayer").GetComponentInParent<PlayerManager>();
            return;
        }


        if(onVent && Input.GetKeyDown(KeyCode.E) && player.isImpostor) {
            system.enterVent(player, this);
        }
    }
}
