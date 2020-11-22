using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    public Image report;
    public Image use;
    public Image kill;

    public Color idle;
    public Color inUse;


    public void setUSEActive(bool value)
    {
        

        if (value)
            use.color = inUse;
        else
            use.color = idle;
    }
    
}
