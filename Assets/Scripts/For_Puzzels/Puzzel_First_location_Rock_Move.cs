using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzel_First_location_Rock : MonoBehaviour
{
    private bool Movment = false; //�������� ������ ��� ��� ���
    private Vector2 MouseOffset; // ������ ����������� �������

    public GameObject finish; // �������� ��������� ������� ������
    bool fin = false; // ������ �� �� ������ �����

    private void OnMouseDown()
    {
        Movment = true;
        MouseOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // ������������ �������� ������� ����������� �������
    }

    private void OnMouseUp()
    {
        Movment = false;
        if (Mathf.Abs(transform.localPosition.x - finish.transform.localPosition.x) <= 8f &&
            Mathf.Abs(transform.localPosition.y - finish.transform.localPosition.y) <= 8f) // ��������, �� ������ �� ����� ������ � �������� � 15f
        {
            transform.position = new Vector2(finish.transform.position.x, finish.transform.position.y); // ���������� ������� �� ������ �����
            fin = true; // ������ �� ������ �����
            Exit_from_puzzel_Rock.AddElement();
        }
    }

    private void Update()
    {
        if (Movment == true && fin == false) //��������, �� ����� �� ����� ������ � ������� �� �� ���� ������
        {
            Vector2 mousePosit = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���������� �������
            transform.position = mousePosit + MouseOffset; // ��������� ��������� �������
        }
    }
    
}
 