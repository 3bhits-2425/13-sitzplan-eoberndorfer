using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensch : MonoBehaviour
{
    public string personName;
    public string rollenInKlasse;
    public Color augenfarbe;
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource myAudioSource;
    void Start()
    {
        Debug.Log("Mein Name: " + personName);
        Debug.Log("Meine Rolle " + rollenInKlasse);
        Debug.Log("Meine Augenfarbe " + augenfarbe);

        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Leertaste gedrueckt");

            myAudioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Leertaste losgelassen");
            myAudioSource.Pause();

        }
    }
}
