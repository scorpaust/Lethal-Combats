using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 1.0f;

    private GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        player1 = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpUp()
	{
        player1.transform.Translate(0f, jumpForce, 0f);
    }
}
