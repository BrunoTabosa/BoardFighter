using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator animator;

    bool isMoving = false;
    Vector3 target = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(isMoving)
        //{
        //    transform.Translate(target * Time.deltaTime);

        //    if(Vector3.Distance(transform.position, target) < 0.02f)
        //    {
        //        isMoving = false;
        //    }
        //}
    }

    public void FaceAndMove(int x, int y)
    {
        isMoving = true;
        target = new Vector3(x, 0, y);
        transform.LookAt(target);
        transform.position = target;
        StartCoroutine(OnMoveComplete());
    }

    IEnumerator OnMoveComplete()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        GameManager.OnMoveComplete();
    }

    public void SetBattleMode(bool value)
    {
        animator.SetBool("InBattle", value);
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void AttackHitResponse()
    {

    }

    public void PlayReceiveHit()
    {
        animator.SetTrigger("Attack");
    }
}
