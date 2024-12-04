using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    private AudioSource myAudioSource;

    //2 Variablen, um den Button und den Text zu finden 
    private GameObject playPauseButton;
    private TMP_Text playPauseButtonText;

 

    public void PlayAudio()
    // AudioSource.play
    {
       // myAudioSource.Play();
       FindAnyObjectByType<Audiomanager>().Play("DrumSolo");
    }
    
    public void PauseAudio()
    // AudioSource.pause
    {
        //myAudioSource.Pause();
        FindAnyObjectByType<Audiomanager>().Pause("DrumSolo"); 
    }

    public void StopAudio()
    {
        myAudioSource.Stop();
    }

    public void PlayPause()
    {   //V1
        if (myAudioSource.isPlaying)
        {
            PauseAudio();
           // playPauseButtonText.text = "Play";
         //   isPlaying = false;
        }
        else
        {
            PlayAudio();
           // playPauseButtonText.text = "Pause";
           // isPlaying = true;
        } 
    }

    public void Update()
    {   //V2
        //Ändere de Button Text
        if (myAudioSource.isPlaying)
        {
            playPauseButtonText.SetText("Pause");
        }
        else
        {
            playPauseButtonText.SetText("Play");
        }
    }

    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        playPauseButton = GameObject.Find("PlayPause");
        playPauseButtonText = playPauseButton.GetComponentInChildren<TMP_Text>();
    }

}

