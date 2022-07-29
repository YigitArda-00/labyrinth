using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance; // Creates a static variable for a MusicControlScript instance

    public bool playing; // Declare a boolean that loops through our music tracks while true
    public AudioSource musicSource; // Our AudioSource component
    public AudioClip[] musicClips; // Our array of music tracks that we will loop through

    private void Awake() // Runs before void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Don't destroy this gameObject when loading different scenes

        if (instance == null) // If the MusicControlScript instance variable is null
        {
            instance = this; // Set this object as the instance
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }
    }

    private void Start() // Start is called on the frame when a script is enabled just before any of the Update methods are called the first time
    {
        playing = true; // Set our "playing" boolean to true
        StartCoroutine(PlayMusicLoop()); // Start our coroutine that will loop through our music tracks
    }

    IEnumerator PlayMusicLoop() // A coroutine allows you to spread tasks across several frames. In Unity, a coroutine is a method that can pause execution and return control to Unity but then continue where it left off on the following frame
    {
        yield return null; // Wait for the next frame and continue execution from this line

        while (playing) // While our "playing" boolean is set to true, our music tracks will continue to loop
        {
            for (int i = 0; i < musicClips.Length; i++) // A for loop where we declare an integer "i" as 0; Continue to for loop while "i" is less than the size of our music clips array; At the end of each loop increase the value of "i" by 1;
            {
                musicSource.clip = musicClips[i]; // Select the music clip in our music clip array that "i" corresponds to

                musicSource.Play(); // Play our AudioSource

                while(musicSource.isPlaying) // While a song is playing
                {
                    yield return null; // Do nothing / wait for end of song
                }
            }
        }
    }

}
