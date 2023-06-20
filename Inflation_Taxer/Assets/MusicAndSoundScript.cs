using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicAndSoundScript : MonoBehaviour
{
    public static bool musicPlaying = true;
    public Button buttonForMusic;
    public AudioSource audioSource;
    public AudioClip music1;
    public AudioClip music2;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;


    void Start()
    {
        StartCoroutine(PlayMusic());
        UpdateButtonImage();


    }

    IEnumerator PlayMusic()
    {
        while (musicPlaying)
        {
            yield return new WaitForSeconds(1);
            audioSource.clip = music1;
            audioSource.Play();
            yield return new WaitForSeconds(music1.length + 6);

            audioSource.clip = music2;
            audioSource.Play();
            yield return new WaitForSeconds(music2.length);
        }
    }
    public void OpenOrCloseMusic()
    {
        if (musicPlaying)
        {
            musicPlaying = false;
            audioSource.Stop();
            UpdateButtonImage();
        }
        else
        {
            StartCoroutine(ChangeMusicState());
        }
    }

    IEnumerator ChangeMusicState()
    {
        yield return new WaitForSeconds(0); // Wait for the next frame!!
        musicPlaying = true;
        StartCoroutine(PlayMusic());
        UpdateButtonImage();
    }

    // Updates button image based on the musicPlaying status
    private void UpdateButtonImage()
    {
        Debug.Log("UpdateButtonImage: " + musicPlaying);

        if (musicPlaying)
        {
            buttonForMusic.GetComponent<Image>().sprite = soundOnSprite;
        }
        else
        {
            buttonForMusic.GetComponent<Image>().sprite = soundOffSprite;
        }
    }
    
    public void MakeVisibleButton(bool state) {
        buttonForMusic.gameObject.SetActive(state);

    }
}