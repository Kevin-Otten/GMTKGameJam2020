using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostInroTriggerBox : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public Rigidbody2D playerRigidbody;

    public float smoothness = 5;
    public float gravityscale = 3;
    private bool triggerd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggerd)
        {
            cameraMovement.Smoothness = smoothness;
            playerRigidbody.gravityScale = gravityscale;
            Destroy(gameObject);
        }
    }
}
