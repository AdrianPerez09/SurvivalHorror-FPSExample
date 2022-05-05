using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] AudioClip[] woodAudioClips;
    [SerializeField] AudioClip[] grassAudioClips;

    [SerializeField] Transform playerTransform;

    [SerializeField] AudioSource source;

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        source.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        AudioClip randomClip = null;

        print("steep");

        if (Physics.Raycast(playerTransform.position, Vector3.down, out RaycastHit hit, 3))
        {
            switch (hit.collider.tag)
            {
                case "Footsteps/Wood":

                    int Woodindex = Random.Range(0, woodAudioClips.Length - 1);

                    randomClip = woodAudioClips[Woodindex];

                    break;

                case "Footsteps/Grass":

                    int Grassindex = Random.Range(0, grassAudioClips.Length - 1);

                    randomClip = grassAudioClips[Grassindex];

                    break;
            }

        }
        return randomClip;
    }
}
