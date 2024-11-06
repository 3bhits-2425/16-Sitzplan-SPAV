using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mensch : MonoBehaviour
{
    public string personName;
    public string rolleInKlasse;
    public Color augenfarbe;
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource myAudiosource;
    void Start()
    {
     Debug.Log("Mein Name: "+ personName);
     Debug.Log("Meine Rolle: "+ rolleInKlasse);
     Debug.Log("Meine Augenfarbe: "+ augenfarbe);
    myAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // sobald die Leertaste gedrueckt wird
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Die Leertaste gedrueckt!");
            myAudiosource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Die Leertaste losgelassen!");
            myAudiosource.Pause();
        }
        
    }
}
