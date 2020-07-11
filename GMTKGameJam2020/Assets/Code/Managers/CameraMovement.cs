using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool focusOnPlayer = true;
    Transform target;
    public Vector3 offset;
    public float Smoothness = 5;

    private void Start()
    {
        target = PlayerManager.instance.transform;
    }

    private void FixedUpdate()
    {
        if(focusOnPlayer)
        {
            MoveAfterPlayer();
        }
    }

    void MoveAfterPlayer()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, targetPos, Smoothness * Time.deltaTime);

        transform.position = smoothedPos;
    }
}
