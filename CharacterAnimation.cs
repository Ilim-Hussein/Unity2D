using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterAnimation : MonoBehaviour
{

    private Animator Anim; // Объявляем приватную переменную Animator


    
    void Start()
    {
        Anim =  GetComponentInChildren <Animator>(); // Наш bool говорим что действие должны получать из Аниматора Animator
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Anim.SetBool("IsRunning", true);
        }

        else
        {
            Anim.SetBool("IsRunning", false);
        }


        if (Input.GetButtonDown("Jump"))
        {
            Anim.SetTrigger("IsJump");
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            Anim.SetTrigger("isAttack");
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Anim.SetTrigger("isAttack2");
        }
    }

}