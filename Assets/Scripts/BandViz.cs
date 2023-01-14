using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandViz : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    void Update()
    {

        if (AudioProc.audioSource.clip)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioProc.frequencyBandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
            Color newColor = new Color(AudioProc.audioBandBuffer[band], AudioProc.audioBandBuffer[band], AudioProc.audioBandBuffer[band]);
            material.SetColor("_Color", newColor);
        }
        else
        {
            //reset scale of the bands
            transform.localScale = new Vector3(transform.localScale.x, startScale, transform.localScale.z);
            // set the color to white
            material.SetColor("_Color", Color.white);
        }

    }
}
