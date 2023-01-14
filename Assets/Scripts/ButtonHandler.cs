using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public string sceneToLoad;
    [SerializeField]
    public bool isTrackSelectorButton;
    [SerializeField]
    public AudioClip associatedAudioClip;
    [SerializeField]
    public AudioSource audioSource;


    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        transform.position = new Vector3(originalPos.x + 100, originalPos.y, originalPos.z);
        if (isTrackSelectorButton)
        {
            //start playing the associated soundtrack
            audioSource.clip = associatedAudioClip;
            audioSource.Play();

            //modify the album image display

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
        if (isTrackSelectorButton)
        {
            //stop the associated soundtrack
            audioSource.Stop();

            //modify the album image display

        }
    }

    public void HandleStart()
    {
        Initiate.Fade(sceneToLoad, Color.black, 2.0f);
    }

    public void HandleQuit()
    {
        Application.Quit();
    }

}
