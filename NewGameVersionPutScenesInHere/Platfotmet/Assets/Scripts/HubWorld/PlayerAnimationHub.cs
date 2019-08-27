using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHub : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        right();
        forward();
        left();
        Upwards();
    }

    void forward()
    {
         if (Input.GetKeyDown(KeyCode.S))
				{
					animator.Play("Base Layer.AndreForward");
				}

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.Play ("Base Layer.Idle");
        }
    }

    void right ()
    {
        if (Input.GetKeyDown(KeyCode.D))
				{
					animator.Play("Base Layer.AndreRight");
				}

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.Play ("Base Layer.IdleRight");
        }
    }

    void left ()
    {
         if (Input.GetKeyDown(KeyCode.A))
				{
					animator.Play("Base Layer.AndreLeft");
				}

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.Play ("Base Layer.Idleleft");
        }
    }

    void Upwards()
    {
         if (Input.GetKeyDown(KeyCode.W))
				{
					animator.Play("Base Layer.AndreUp");
				}

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.Play ("Base Layer.IdleBack");
        }
    }
}
