using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_location_magican : MonoBehaviour
{
    private Inventory Inven; // Инвентарь 
    private int PeaceOfStick = 0;
    private static bool HaveStick = false;

    public CircleCollider2D Teleport;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null && Input.GetKey(KeyCode.E) == true) //Проверка, находится ли игрок в Collider нужного объекта
        {
            Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // Присваивает значения инвентаря игрока
            for (int i = 0; i < 5; i++)
            {
                if (Inven.Slots[i].transform.Find("Cristal(Clone)") || Inven.Slots[i].transform.Find("Garda(Clone)") || Inven.Slots[i].transform.Find("Stick(Clone)") ) 
                {
                    GameObject parentObject = Inven.Slots[i]; // Присваивает переменной слот, с нужным дочерним объектом
                    foreach (Transform child in parentObject.transform) // Данный цикл уничтожит каждый дочерний объект слота
                    {
                        Destroy(child.gameObject);// Уничтожает этот дочерний объект
                        PeaceOfStick++;
                    }
                    Inven.Full[i] = false;
                }
                if (PeaceOfStick == 3) // Проверяет наличие нужного объекта в массиве Slots
                {
                    HaveStick = true;
                    break;
                }
            }

        }

    }
    private void Update()
    {
        if (HaveStick == true)
        {
            Teleport.enabled = true;
        }
    }
}
