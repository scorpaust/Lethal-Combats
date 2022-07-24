using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 1.0f;

    private GameObject player1;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player1 = transform.parent.gameObject;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
            anim.SetTrigger("LightPunch");
		}

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("HeavyPunch");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            anim.SetTrigger("LightKick");
        }
    }

    public void JumpUp()
	{
        player1.transform.Translate(0f, jumpForce, 0f);
    }

    public void FlipUp()
    {
        player1.transform.Translate(0f, jumpForce, 0f);
        player1.transform.Translate(0.5f, 0f, 0f);
    }

    public void FlipBack()
    {
        player1.transform.Translate(0f, jumpForce, 0f);
        player1.transform.Translate(-0.5f, 0f, 0f);
    }
}
