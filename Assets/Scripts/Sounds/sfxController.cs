using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxController : MonoBehaviour
{
    public static sfxController SharedInstance;

    // Start is called before the first frame update
    void Start()
    {
        /* GetComponent<AudioSource>().volume = VolumeController.sfxVolume; */
        SharedInstance = this;
    }

    // Play the sound
    public void PlayClip(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
