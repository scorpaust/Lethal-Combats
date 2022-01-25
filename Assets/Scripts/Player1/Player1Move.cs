using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.05f;

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private GameObject opponent;

    private Animator anim;

    private bool isJumping = false;

    private bool canWalkLeft = true;

    private bool canWalkRight = true;

    private AnimatorStateInfo Player1Layer0;

    private Vector3 opPosition;

    private bool facingLeft = false;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        StartCoroutine(FaceRight());
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void Move()
	{
        // Listen to the animator
        Player1Layer0 = anim.GetCurrentAnimatorStateInfo(0);

        // Cannot exit screen
        ClampPositionToScreen();

        // Walking left and right
        if (Player1Layer0.IsTag("Motion"))
        {
            if (Input.GetAxis("Horizontal") > 0 && canWalkRight)
            {
                anim.SetBool("Forward", true);
                transform.Translate(walkSpeed, 0f, 0f);
            }

            if (Input.GetAxis("Horizontal") < 0 && canWalkLeft)
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

        FaceOpponent();

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

    private void ClampPositionToScreen()
	{
        Vector3 screenBounds = Camera.main.WorldToScreenPoint(transform.position);

        if (screenBounds.x > Screen.width - 300f)
		{
            canWalkRight = false;
		}

        else if (screenBounds.x < 200f)
        {
            canWalkLeft = false;
        }

        else if (screenBounds.x > 200f && screenBounds.x < Screen.width - 300f)
		{
            canWalkRight = true;

            canWalkLeft = true;
		}
    }

    private Vector3 GetOpponentPosition()
	{
        return opponent.transform.position;
	}

    private void FaceOpponent()
	{
        opPosition = GetOpponentPosition();

        // Flip around to face opponent
        if (opPosition.x > player1.transform.position.x)
		{
            StartCoroutine(FaceLeft());
		}

        // Flip around to face opponent
        if (opPosition.x < transform.position.x)
        {
            StartCoroutine(FaceRight());
        }
    }

    private IEnumerator FaceLeft()
	{
        if (facingLeft)
		{
            facingLeft = false;

            facingRight = true;

            yield return new WaitForSeconds(0.15f);

            player1.transform.Rotate(0f, -180f, 0f);

            anim.SetLayerWeight(1, 0);
        }
        
	}

    private IEnumerator FaceRight()
    {
        if (facingRight)
        {
            facingRight = false;

            facingLeft = true;

            yield return new WaitForSeconds(0.15f);

            player1.transform.Rotate(0f, -180f, 0f);

            anim.SetLayerWeight(1, 1);
        }
    }
}
