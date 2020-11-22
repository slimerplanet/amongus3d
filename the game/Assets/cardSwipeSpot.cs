using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardSwipeSpot : MonoBehaviour
{
    public TaskManager manager;
    public task_cardSwipe task;
    public Icons icons;

    bool inTrigger;

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
        if(inTrigger && Input.GetKeyDown(KeyCode.E) && manager.hasCardSwipe && !manager.cardSwipeCompleted)
        {
            task.OpenTask();
        }
    }
}
