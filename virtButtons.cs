using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System; 

public class virtButtons : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject[] virtualButtonBehaviors;
    public GameObject[] videoQuads;
    public UnityEngine.Video.VideoPlayer[] videoPlayers; 
    public string vbName;
    public AudioClip[] aClips;
    public AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start!   ====");
        virtualButtonBehaviors = new GameObject[3];
        virtualButtonBehaviors[0] = GameObject.Find("VirtButtonC");
        virtualButtonBehaviors[1] = GameObject.Find("VirtButtonD");
        virtualButtonBehaviors[2] = GameObject.Find("VirtButtonE");

        for (int i = 0; i<virtualButtonBehaviors.Length; i++)
        {
            virtualButtonBehaviors[i].GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        }

        videoQuads = new GameObject[3];
        videoQuads[0] = GameObject.Find("QuadC");
        videoQuads[1] = GameObject.Find("QuadD");
        videoQuads[2] = GameObject.Find("QuadE");

        videoPlayers = new UnityEngine.Video.VideoPlayer[3];
        for (int i = 0; i < videoQuads.Length; i++)
            videoPlayers [i] = videoQuads[i].GetComponent<UnityEngine.Video.VideoPlayer>();

        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("button down!");
        vbName = vb.VirtualButtonName;
        switch (vbName)
        {
            case "VirtButtonC":
                myAudioSource.clip = aClips[0];
                myAudioSource.Play();
                videoPlayers[0].Play();

                Debug.Log("buttonC down!");
                break;

            case "VirtButtonD":
                myAudioSource.clip = aClips[1];
                myAudioSource.Play();
                videoPlayers[1].Play();
                break;

            case "VirtButtonE":
                myAudioSource.clip = aClips[2];
                myAudioSource.Play();
                videoPlayers[2].Play();
                break;

        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}
