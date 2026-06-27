using System.Collections;
using UnityEngine;

public class music_TRansection : MonoBehaviour
{
    public AudioSource trackA;
    public AudioSource trackB;
    public float fadeDuration = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the smooth transition
            StartCoroutine(Crossfade(trackA, trackB, fadeDuration));
        }
    }

    private IEnumerator Crossfade(AudioSource fadeOutSource, AudioSource fadeInSource, float duration)
    {
        fadeInSource.Play();
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            // Smoothly interpolate volumes
            fadeOutSource.volume = Mathf.Lerp(1f, 0f, currentTime / duration);
            fadeInSource.volume = Mathf.Lerp(0f, 1f, currentTime / duration);
            yield return null;
        }

        fadeOutSource.Stop();
    }
}

