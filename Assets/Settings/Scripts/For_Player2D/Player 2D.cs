using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public Mesto posit; // ���������� ������� ��������� ��� �������� �� ������� � �������
    //public Mesto first_position; 
    public float speed = 5.0f; // �������� ����������� ������
    public Animator anim; // �������� ������ ���������

    private bool Turn = true; // ��������, �������� �������� ��� ���
    private Rigidbody2D rb; // ������ �� ��������� Rigidbody2D 
    private Vector2 movement; // ��������� ����������� �������� ������
    private float move; // ����������� ��������� �� �����������

    void Start()
    {
        transform.position = posit.initial;
        // �������������� ��������� Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // �� ���������� �������� ���������
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // �������� �������� ������
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // ��������� �������� ����������� ��� ��������
        anim.SetFloat("HorisontalMove", Mathf.Abs(horizontalInput));
        if (horizontalInput != 0)
        {
            //���������� ����������� �������� �� �����������
            movement = new Vector2(horizontalInput, 0);
            move = horizontalInput;

            // ������� ��������� *������*
            if(horizontalInput < 0 && Turn)
            {
                Turning();
            }

            else if (horizontalInput > 0 && !Turn)
            {
                Turning();
            }
            // *�����*
        }

        else
        {
            movement = new Vector2(horizontalInput, 0); 
            move = horizontalInput;
        }
        transform.Translate(speed * Time.deltaTime * move, 0, 0); // �� �������� ����������� ���������
        movement = new Vector2(horizontalInput, verticalInput); 

    }

    void FixedUpdate()
    {
        // ��������� �������� � ������ ��� ����������� ��������������� ������
        rb.velocity = movement * speed;
    }

    // ������� �������� ���������
    private void Turning()
    {
        Turn = !Turn;        
        Vector3 Scale = transform.localScale;
        Scale.x *= -1; //�������� ��� ��������
        transform.localScale = Scale; //��������� �������� ��������� �� ���������� 
    }
}
