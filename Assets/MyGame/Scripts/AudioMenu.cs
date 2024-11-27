using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    private TMP_Text playPauseButtonText;
    private GameObject playPauseButton;

    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        //1. Finde das Textfeld des PlayPause-Buttons
        playPauseButton = GameObject.Find("playPauseButton");
        //2. Finde das Textfeld als Kind des Buttons
        playPauseButtonText = playPauseButton.GetComponentInChildren<TMP_Text>();
    }

    public void PlayAudio()
    {
        // Spiele die Audio-Source 
        
        Debug.Log("Audio play");
        FindAnyObjectByType<AudioManager>().Play("Sound1");
        /*Langform:
         * AudioManager audioManager = FindAnyObjectByType<AudioManager>();
         * audioManager.Play("16-my Sound-SPAV");
        */
    }

    public void PauseAudio()
    {
        // Pausiere die Audio-Source
        Debug.Log("Audio paused");
        FindAnyObjectByType<AudioManager>().Pause("Sound1");
    }

    public void StopAudio()
    {
        // Stoppe die Audio-Source
        myAudioSource.Stop();
    }

    public void PlayPause()
    {
        /*if (myAudioSource.isPlaying)
        {
            myAudioSource.Pause();
            playPauseButtonText.text = "Play";
            Debug.Log("Audio paused");
        }
        else
        {
            myAudioSource.Play();
            playPauseButtonText.text = "Pause";
            Debug.Log("Audio play");
     
        }*/
    }

    public void Update()
    {
        //Ändere den Button-Text
        //abhängig vom Zusatnd der AusioSource
        if (myAudioSource.isPlaying)
        {
            playPauseButtonText.text = "Pause";
            //myAudioSource.Play();
        }
        else
        {
            playPauseButtonText.text = "Play";
            //myAudioSource.Pause();
        }
    }
}

