using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public Mesto posit; // Сохранение позиции персонажа при переходе от локации к локации
    //public Mesto first_position; 
    public float speed = 5.0f; // Скорость перемещения игрока
    public Animator anim; // Анимация ходьбы персонажа

    private bool Turn = true; // Проверка, повернут персонаж или нет
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D 
    private Vector2 movement; // Сохраняет направление движения игрока
    private float move; // Перемещения персонажа по горизонтали

    void Start()
    {
        transform.position = posit.initial;
        // Инициализируем компонент Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Не допускайте вращения персонажа
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Проверка движения игрока
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Активация анимации бездействия или движения
        anim.SetFloat("HorisontalMove", Mathf.Abs(horizontalInput));
        if (horizontalInput != 0)
        {
            //Сохранение направления движения по горизонтали
            movement = new Vector2(horizontalInput, 0);
            move = horizontalInput;

            // Поворот персонажа *начало*
            if(horizontalInput < 0 && Turn)
            {
                Turning();
            }

            else if (horizontalInput > 0 && !Turn)
            {
                Turning();
            }
            // *конец*
        }

        else
        {
            movement = new Vector2(horizontalInput, 0); 
            move = horizontalInput;
        }
        transform.Translate(speed * Time.deltaTime * move, 0, 0); // По кадровое перемещение персонажа
        movement = new Vector2(horizontalInput, verticalInput); 

    }

    void FixedUpdate()
    {
        // Примените движение к игроку для обеспечения согласованности физики
        rb.velocity = movement * speed;
    }

    // Функция поворота персонажа
    private void Turning()
    {
        Turn = !Turn;        
        Vector3 Scale = transform.localScale;
        Scale.x *= -1; //Значение для поворота
        transform.localScale = Scale; //Изменение картинки персонажа на повернутую 
    }
}
