using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{

    //Variablen umden Button und den text zu finden

    private GameObject playPauseButton; //Button
    private TMP_Text playPauseButtonText; //Text auf dem Button



    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        //finde das Textfeld des Play/Pause Buttons
        playPauseButton = GameObject.Find("PlayPause");

        //finde den Text des Play/Pause Buttons
        playPauseButtonText = playPauseButton.GetComponentInChildren<TMP_Text>();


    }

    // Update is called once per frame
    public void PlayAudio()
    {
        Debug.Log("Audio started");
        // start playing the audio
        myAudioSource.Play();
    }
    public void PauseAudio()
    {
        Debug.Log("Audio paused");
        // pause the audio
        myAudioSource.Pause();

    }
    public void StopAudio()
    {
        Debug.Log("Audio stopped");
        // stop the audio
        myAudioSource.Stop();
    }
    public void playPauseAudio()
    {

        if (myAudioSource.isPlaying)
        {
        
            myAudioSource.Pause();
           
        }
        else
        {
            
            myAudioSource.Play();
            
        }
    }
    public void Update()
    {
        if (myAudioSource.isPlaying)
        {
            playPauseButtonText.text = "Play";
            //myAudioSource.Pause();
            Debug.Log("Audio paused");
        }
        else
        {
            playPauseButtonText.text = "Pause";
           // myAudioSource.Play();
            Debug.Log("Audio play");

        }
    }
}