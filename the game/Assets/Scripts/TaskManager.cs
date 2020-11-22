using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : NetworkBehaviour
{

    public Slider taskBar;
    public NetworkManager network;
    public downUpLoadSpot[] dataSpots;
    public downUpLoadSpot uploadSpot;

    public wiresSpot[] wiresSpots;
    public int firstTask;
    public int secondTask;
    public int thirdTask;
    [SyncVar] public int taskscompleted;
    public bool isIntask;

    [Header("tasks completed")]
    public bool downloadCompleted;
    public bool uploadCompleted;
    public bool cardSwipeCompleted;
    public bool allWiresCompleted;
    public int wiresCompleted;

    [Header("have tasks")]
    public bool hasDownloadupload = true;
    public bool hasCardSwipe = true;
    public bool hasWires;



    private void Start()
    {
        dataSpots[Random.Range(0, dataSpots.Length)].hasTaskHere = true;

        randomise();

    }

    void randomise()
    {
        firstTask = Random.Range(0, wiresSpots.Length);
        secondTask = Random.Range(0, wiresSpots.Length);
        thirdTask = Random.Range(0, wiresSpots.Length);

        bool t = true ;
        while(t)
        {
            int u = 0;
            if (firstTask == secondTask || firstTask == thirdTask)
            {
                firstTask = Random.Range(0, wiresSpots.Length);
            }
            else
                u++;
                
            if (secondTask == firstTask || secondTask == thirdTask)
            {
                firstTask = Random.Range(0, wiresSpots.Length);
            }else
                u++;
            if (thirdTask == firstTask || thirdTask == secondTask)
            {
                thirdTask = Random.Range(0, wiresSpots.Length);
            }else
                u++;
            if(u >= 3)
            {
                t = false;
            }
        }

        wiresSpots[firstTask].wirePart = 0;
        wiresSpots[secondTask].wirePart = 1;
        wiresSpots[thirdTask].wirePart = 2;









    }
    bool t = true;
    private void Update()
    {
        taskBar.maxValue = network.numPlayers * 3;
        taskBar.value = taskscompleted;




        if (!downloadCompleted)
        {
            uploadCompleted = false;
        }
        else
        {
            uploadSpot.hasTaskHere = true;
        }
        

        if(wiresCompleted == 3 )
        {
            allWiresCompleted = true;

            if(t)
            {
                taskscompleted++;
                t = false;
            }
        }
            

    }
}
