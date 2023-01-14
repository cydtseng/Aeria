using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandViz : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioProc.frequencyBandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
        Color newColor = new Color(AudioProc.audioBandBuffer[band], AudioProc.audioBandBuffer[band], AudioProc.audioBandBuffer[band]);
        material.SetColor("_Color", newColor);
    }
}
