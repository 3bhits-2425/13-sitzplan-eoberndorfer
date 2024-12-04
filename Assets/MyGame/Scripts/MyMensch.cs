using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensch : MonoBehaviour
{
    public string RolleInKlasse;
    public Color Augenfarbe;
    public string Name;
    [SerializeField] private AudioSource myAudioSource;
    void Start()
    {
        Debug.Log("Mein Name: " + Name);
        Debug.Log("Meine Rolle in der Klasse: " + RolleInKlasse);
        Debug.Log("Meine Augenfarbe: " + Augenfarbe);

        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // sobald die Leertaste gedrückt wird  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Leertaste wurde gedrueckt");
            myAudioSource.Play();
        } 
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Leertaste wurde losgelassen");
            myAudioSource.Stop();
        }
    }
}
