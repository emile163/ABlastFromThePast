using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingennemy : MonoBehaviour
{
    public Transform turnRight;
    public Transform turnLeft;
    private Transform target;
    public float speed = 1;
    private Animator mAnimator = null;

    void Start()
    {
        mAnimator = this.GetComponent<Animator>();
        target = turnLeft;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector2.Distance(transform.position, target.position) <= 0.01f)
		{
            nextPoint();
		}
    }

    void nextPoint()
	{
        if(target == turnLeft)
		{
            target = turnRight;
            mAnimator.SetBool("GoingLeft", true);
            mAnimator.SetBool("goingRight", false);
           

        }
        else if(target == turnRight)
		{
            target = turnLeft;
            mAnimator.SetBool("goingRight", true);
            mAnimator.SetBool("GoingLeft", false);

        }
	}

    public void destroy()
	{
        
        mAnimator.SetBool("goingRight", false);
        mAnimator.SetBool("GoingLeft", false);
        Destroy(this);
    }
}
