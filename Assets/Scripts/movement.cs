using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class movement : MonoBehaviour
{
    public bool isMoving;
    public bool isReachTheCorner;
    public float speed = 50f;
    public Rigidbody rb;

    public int minSwipeRange = 500;
    Vector3 direction;
    Vector3 nextWallPos;

    Vector2 swipePosFirst;
    Vector2 swipePosSecond;
    Vector2 currentSwipe;




    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!isMoving && !GameManager.GameOver)
        {
            rb.velocity = speed * direction;
            StartCoroutine("TimeDelay");

        }
        if (nextWallPos != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, nextWallPos) < 0.5)
            {
                isMoving = false;
                direction = Vector3.zero;
                nextWallPos = Vector3.zero;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && nextWallPos == Vector3.zero)
        {
            swipePosFirst = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //Debug.Log(timer);
            if (swipePosSecond != Vector2.zero)
            {

                currentSwipe = swipePosFirst - swipePosSecond;
                if (currentSwipe.sqrMagnitude < minSwipeRange)
                {
                    return;
                }
                //currentSwipe.Normalize();

                //yukarı ve aşağı
                if (currentSwipe.x > -10f && currentSwipe.x < 10f)
                {
                    
                    if (currentSwipe.y > 4f)
                    {
                        setDirection(Vector3.forward);
                    }
                    if (currentSwipe.y < -4f)
                    {
                        setDirection(Vector3.back);
                        StartCoroutine("TimeDelay");
                    }
                }

                // sağ sol
                else if (currentSwipe.y > -10f && currentSwipe.y < 10f)
                {
                    if (currentSwipe.x > 4f)
                    {
                        setDirection(Vector3.right);
                        StartCoroutine("TimeDelay");
                    }
                    if (currentSwipe.x < -4f)
                    {
                        setDirection(Vector3.left);
                        StartCoroutine("TimeDelay");
                    }
                }
            }
            swipePosSecond = swipePosFirst;

        }

        if (Input.GetMouseButtonUp(0)){
            swipePosSecond = Vector2.zero;
        }
    }

    public void setDirection(Vector3 forSetDirection)
    {
        direction = forSetDirection;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, forSetDirection, out hit, 100f))
        {
            nextWallPos = hit.point;
        }
        isMoving = false;
    }

    public IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(5f);
    }
}
