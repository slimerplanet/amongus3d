using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public bool isImpostor;
    public bool isDead;

    public int color;

    public Texture[] colors;
    public Texture[] backbagColors;

    public Material bodyMat;
    public Material backMat;

    public Light flashLight;
    public sabotageManager sabotage;

    [Header("networking")]
    public string remotePlayerLayerName;
    public GameObject body;
    public Behaviour[] stufftoDisable;


    private void Start()
    {
        sabotage = FindObjectOfType<sabotageManager>();

        if(!isLocalPlayer)
        {
            for (int i = 0; i < stufftoDisable.Length; i++)
            {
                stufftoDisable[i].enabled = false;
            }
            body.layer = LayerMask.NameToLayer(remotePlayerLayerName);
        }else
        {
            gameObject.tag = "localplayer";
        }


    }
    private void Update()
    {
        bodyMat.mainTexture = colors[color];
        backMat.mainTexture = backbagColors[color];

        if(sabotage.lightsSabotaged)
        {
            flashLight.intensity = 0.1f;
        }

        if(Input.GetKeyDown(KeyCode.K) && isImpostor)
        {
            sabotageLigths();
        }
    }
    [Client]
    public void sabotageLigths()
    {
        var sabo = FindObjectOfType<sabotageManager>();

        sabo.CMDsabotageLights();
    }

}
