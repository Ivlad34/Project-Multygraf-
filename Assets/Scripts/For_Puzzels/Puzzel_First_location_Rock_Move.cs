using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzel_First_location_Rock : MonoBehaviour
{
    private bool Movment = false; //Проверка нажата ЛКМ или нет
    private Vector2 MouseOffset; // Вектор перемещения курсора

    public GameObject finish; // Конечное положение кусочка паззла
    bool fin = false; // Объект не на нужном месте

    private void OnMouseDown()
    {
        Movment = true;
        MouseOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // Присваивание значения вектора перемещения курсора
    }

    private void OnMouseUp()
    {
        Movment = false;
        if (Mathf.Abs(transform.localPosition.x - finish.transform.localPosition.x) <= 8f &&
            Mathf.Abs(transform.localPosition.y - finish.transform.localPosition.y) <= 8f) // Проверка, на нужном ли месте объект с разницей в 15f
        {
            transform.position = new Vector2(finish.transform.position.x, finish.transform.position.y); // Постановка объекта на нужное место
            fin = true; // Объект на нужном месте
            Exit_from_puzzel_Rock.AddElement();
        }
    }

    private void Update()
    {
        if (Movment == true && fin == false) //Проверка, на месте ли кусок паззла и наведен ли на него курсор
        {
            Vector2 mousePosit = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Координаты курсора
            transform.position = mousePosit + MouseOffset; // Изменение положения объекта
        }
    }
    
}
 