using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{ 
    [SerializeField] private float speed = 5f; // Скорость персонажа 
    [SerializeField] private float jumpForce = 6f;// Сила прыжка 
    [SerializeField] public int healch ; //колличество жизней персонажа

    public int numberOfLives;
    public Image[] lives;
    public Sprite fullLive; //Сюда мы помещаем нажи полные сердечки
    public Sprite emptyLive;//Сюда мы помещаем нажи пустые сердечки

    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private bool isGrounded = false;
    private bool FacingRight = true;

   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Обращаемся к компоненту Rigidbody2D на котором закреплем наш персонаж,и заключаем его в переменную rb;
        spriteRender = GetComponentInChildren<SpriteRenderer>(); // // Обращаемся к компоненту SpriteRenderer на котором закреплем наш персонаж,и заключаем его в переменную spriteRender;
    }


    void Update ()
    {
        
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            Run();
            Flip(horizontal);
        }

        if (Input.GetButtonDown("Jump") && isGrounded )
        {   
            isGrounded = false;
            Jump();
        }

        if (healch > numberOfLives) 
        { 
          healch = numberOfLives;
        }

        for (int i = 0; i < lives.Length; i++)
        {

            if (i < healch)
            {
                lives[i].sprite = fullLive;
            }

            else 
            {
                lives[i].sprite = emptyLive;
            }
            

            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }

            else
            {
                lives[i].enabled = false;
            }
        }


    }


    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal"); // Тут мы указываем направление
        transform.position = Vector3.MoveTowards(transform.position,transform.position + dir, speed * Time.deltaTime); // Для перемещения применяем метод MoveTowards который принемает в себя 3 параметра
        spriteRender.flipX = dir.x < 0.0f;                                                                             // В качестве первого параметра мы педерадаем текущее местоположение transform.position
                                                                                                                       // В качестве второго параметра мы педерадаем направление transform.position + dir
                                                                                                                       // В качестве третьего параметра мы передаем скорость умножанную на время для правлоности speed * Time.deltaTime
    }

    private void Jump() 
    {
        rb.AddForce(transform.up * jumpForce,ForceMode2D.Impulse);
    }
   

    private void OnCollisionEnter2D() // Проверяем стоим ли мы на земле 
    {
        isGrounded = true;
    }


    void Flip(float horizontall)
    {
        if (horizontall > 0 && !FacingRight || horizontall < 0 && FacingRight)
        {
            FacingRight = !FacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }


    }   


