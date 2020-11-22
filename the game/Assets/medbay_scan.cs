using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medbay_scan : MonoBehaviour
{
    public Animator animator;
    public Icons icons;
    bool inTrigger;
    public bool completed;

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
        if(inTrigger && Input.GetKeyDown(KeyCode.E)) {

        }
    }
}
