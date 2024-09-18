using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkleEnemi : CharacterEnemi
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject AttackArea;

    private bool deActive = true;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime; 
        if ( deActive)
        {
            Hit();
        } 
        else
        {
            StartCoroutine(Idile());
        }
    }

    private IEnumerator Idile()
    {
        animator.SetBool("Idile", false);
        AttackArea.SetActive(false);
        yield return new WaitForSeconds(4);

        stopIdile();
    }
    private void stopIdile()
    {
        deActive = true;
        timer = 0;
    }
    private void Hit()
    {
        animator.SetBool("Idile", true);
        AttackArea.SetActive(true);

        if ( timer > 4 )
        {
            Idile();
            deActive = false;
        }
    }

}
