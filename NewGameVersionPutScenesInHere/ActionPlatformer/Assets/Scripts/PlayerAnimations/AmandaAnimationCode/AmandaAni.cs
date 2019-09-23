using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmandaAni : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.D))
				{
					animator.Play("Base Layer.Amanda Run");
				}

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.Play ("Base Layer.Amanda");
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("Base Layer.Amanda Run");
        }

          if (Input.GetKeyUp(KeyCode.A))
        {
            animator.Play ("Base Layer.Amanda");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play ("Base Layer.AmandaJump");

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.Play ("Amanda Run");
        }

    }
}
