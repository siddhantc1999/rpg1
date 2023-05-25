using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPos;
    float stoppingDistance;
    float moveSpeed;
    [SerializeField] Animator animator;
    float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        stoppingDistance = 0.1f;
        moveSpeed = 4f;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetPos) > stoppingDistance)
        {
            Debug.Log("here in greater than stopping distance"+gameObject.name);
            Vector3 moveDirection = (targetPos - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            //Quaternion targetRot = Quaternion.LookRotation(targetPos);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot,Time.deltaTime* 10f);
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * 10f);
            
            animator.SetBool("IsWalking",true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        //if(Input.GetMouseButtonDown(1))
        //{

        //    //problem lies here
        //    targetPos = Mouseworldpos.GetMousepos();
        //}
    }

    public void Settargetpos(Vector3 targetpos)
    {
        this.targetPos = targetpos;
    }
}
