using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public AudioSource source;
    public AudioClip switchOn;
    public AudioClip switchOff;

    [SerializeField] GameObject spotlight;
    private bool flashlightActive;

    void Start()
    {
        spotlight.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashlightActive)
            {
                spotlight.gameObject.SetActive(true);
                flashlightActive = true;

                source.PlayOneShot(switchOn);
            }
            else
            {
                spotlight.gameObject.SetActive(false);
                flashlightActive = false;

                source.PlayOneShot(switchOff);
            }
        }       
    }
}
