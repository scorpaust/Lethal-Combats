using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.05f;

    private Animator anim;

    private bool isJumping = false;

    private AnimatorStateInfo Player1Layer0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void Move()
	{
        Player1Layer0 = anim.GetCurrentAnimatorStateInfo(0);

        // Walking left and right
        if (Player1Layer0.IsTag("Motion"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                anim.SetBool("Forward", true);
                transform.Translate(walkSpeed, 0f, 0f);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("Backward", true);
                transform.Translate(-walkSpeed, 0f, 0f);
            }
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Backward", false);
            anim.SetBool("Forward", false);
        }

        //Jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            if (!isJumping)
            {
                isJumping = true;
                anim.SetTrigger("Jump");
                StartCoroutine(JumpPause());
            }
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

    private IEnumerator JumpPause()
	{
        yield return new WaitForSeconds(1.0f);
        isJumping = false;
	}
}
