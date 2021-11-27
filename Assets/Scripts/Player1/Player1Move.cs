using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void Move()
	{
        // Walking left and right
        if (Input.GetAxis("Horizontal") > 0)
		{
            anim.SetBool("Forward", true);
		}

        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Backward", true);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Backward", false);
            anim.SetBool("Forward", false);
        }

        //Jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetTrigger("Jump");
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("Crouch", true);
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            anim.SetBool("Crouch", false);
        }
    }
}
