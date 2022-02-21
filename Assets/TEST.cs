using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private bool goingUp;
    private float speed = 6;
    
    private void Update()
    {
        if (goingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y > 30)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y < 0)
            {
                goingUp = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (following)
            {
                followMovement.UnFollow();
            }
            else
            {
                followMovement.Follow(debugTransform);
            }
        }
    }

    public FollowMovement followMovement;
    public Transform debugTransform;
    private bool following = false;
}
