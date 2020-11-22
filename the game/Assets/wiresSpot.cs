using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiresSpot : MonoBehaviour
{
    public Icons icons;
    public TaskManager manager;
    public WireTask task;
    public int wirePart = -1;

    public bool inTrigger;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("localplayer"))
        {
            icons.setUSEActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("localplayer"))
        {
            inTrigger = false;
            icons.setUSEActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && manager.hasWires && inTrigger && manager.wiresCompleted == wirePart)
        {
            task.OpenTask();
        }
    }
}
