using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map : MonoBehaviour
{
    public GameObject mapImage;
    bool showMap = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showMap = !showMap;
        }

        mapImage.SetActive(showMap);
    }
}
