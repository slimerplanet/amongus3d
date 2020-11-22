using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class downUpLoadSpot : MonoBehaviour
{

    public bool inTrigger;
    public task_downloadUpload task;
    public TaskManager manager;
    public Icons icons;

    public bool hasTaskHere;
    public bool upload;

    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.layer == LayerMask.NameToLayer("localplayer"))
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
        if(inTrigger && Input.GetKeyDown(KeyCode.E) && hasTaskHere)
        {
            if(!upload && !manager.downloadCompleted)
                task.opentask();
            if (upload && manager.downloadCompleted && !manager.uploadCompleted)
                task.opentask();
        }

    }
}
