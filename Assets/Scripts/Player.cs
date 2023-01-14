using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public AudioSource hitSound;


    // Start is called before the first frame update
    void Start()
    {
        //remove the cursor visible
        Cursor.visible = false;
        cam = GameObject.Find("3D Tunnel Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = cam.nearClipPlane + 5;
        worldPosition = cam.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBlock"))
        {
            //play sound
            hitSound.Play();
            //show fancy effect

            //add score to player 
            Debug.Log("score!");
            // Destroy(other.gameObject);
        }
    }
}
