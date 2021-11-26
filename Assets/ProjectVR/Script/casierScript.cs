using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casierScript : MonoBehaviour
{
    [SerializeField] GameObject forceField;
    [SerializeField] AudioClip cardConfirmClip;
    [SerializeField] AudioClip cardDenieClip;

    AudioSource audioSource;
    bool cardAccepted;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        cardAccepted = false;
        CardScript cardScript = other.gameObject.GetComponentInChildren<CardScript>();
        Debug.Log("Card swipped");
        if (cardScript != null)
        {
            foreach(GameObject locker in cardScript.locker)
            {
                if (locker == transform.gameObject)
                {
                    Debug.Log("Card accepted");
                    forceField.SetActive(false);
                    playAudio(cardConfirmClip);
                    cardAccepted = true;
                    break;
                }
            }
            if (cardAccepted == false)
            {
                Debug.Log("Card declined");
                playAudio(cardDenieClip);
            }
        }
        else
        {
            Debug.Log("That ain't a card mate");
        }
    }

    private void playAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
