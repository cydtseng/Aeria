using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position = new Vector3(originalPos.x + 100, originalPos.y, originalPos.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
    }

    public void HandleStart()
    {
        Debug.Log("Start");
    }

    public void HandleQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
