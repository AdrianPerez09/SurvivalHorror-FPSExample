using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject spotlight;
    private bool flashlightActive;

    // Start is called before the first frame update
    void Start()
    {
        spotlight.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashlightActive)
            {
                spotlight.gameObject.SetActive(true);
                flashlightActive = true;
            }
            else
            {
                spotlight.gameObject.SetActive(false);
                flashlightActive = false;
            }
        }       
    }
}
