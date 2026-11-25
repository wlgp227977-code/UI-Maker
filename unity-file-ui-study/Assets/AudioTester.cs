using UnityEngine;
using System.Collections;

public class AudioTester : MonoBehaviour
{
    public AudioClip[] clips;

    private IEnumerator Start()
    {
        foreach (AudioClip clip in clips)
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            audioSource.clip = clip;
            audioSource.Play();

            yield return new WaitForSeconds(clip.length);
        }
    }
}