using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task_downloadUpload : MonoBehaviour
{
    public bool isUpload;

    public Animator animator;
    public TaskManager manager;
    public GameObject graphics;

    bool downloadStarted;
    public bool downloadFinished;

    bool t = true;
    public void startDownload()
    {
        if (downloadStarted || downloadFinished)
            return;
        if (isUpload && !manager.downloadCompleted)
            return;


        animator.SetTrigger("start");
        downloadStarted = true;
    }

    private void Update()
    {
        
        if (downloadFinished && t)
        {
            if (!isUpload)
                manager.downloadCompleted = true;
            else
                manager.uploadCompleted = true;
            manager.isIntask = false;
            graphics.SetActive(false);

            if (isUpload)
                manager.taskscompleted += 1;
            t = false;
        }
    }

    public void opentask()
    {
        manager.isIntask = true;
        graphics.SetActive(true);
        
    }
}
