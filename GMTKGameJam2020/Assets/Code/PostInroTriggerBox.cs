using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostInroTriggerBox : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public Rigidbody2D playerRigidbody;

    private bool triggerd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggerd)
        {
            cameraMovement.Smoothness = 5;
            playerRigidbody.gravityScale = 3;
            Destroy(gameObject);
        }
    }
}
