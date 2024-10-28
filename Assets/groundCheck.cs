using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    // Start is called before the first frame update
   public float distanceToCheck=0.5f;
    public bool isGrounded;

    public void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
