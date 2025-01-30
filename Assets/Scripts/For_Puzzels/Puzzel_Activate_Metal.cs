using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzel_Activate_Metal : MonoBehaviour
{
    public GameObject[] Rock;
    private Inventory Inven; // Инвентарь 

    public static bool FlagGarda = false;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null && Input.GetKey(KeyCode.E) == true) //Проверка, находится ли игрок в Collider нужного объекта
        {
            Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // Присваивает значения инвентаря игрока
            for (int i = 0; i < 5; i++) 
            {
                if (Inven.Slots[i].transform.Find("Rock_Final(Clone)") == true) // Проверяет наличие нужного объекта в массиве Slots
                {
                    GameObject parentObject = Inven.Slots[i]; // Присваивает переменной слот, с нужным дочерним объектом
                    foreach (Transform child in parentObject.transform) // Данный цикл уничтожит каждый дочерний объект слота
                    {
                        Destroy(child.gameObject);// Уничтожает этот дочерний объект
                    }
                    Inven.Full[i] = false;
                    Add_Object.AddToInventory(Inven, Rock); // Добавляет новые объекты
                    break;
                }
                if (Inven.Slots[i].transform.Find("Metal(Clone)") == true) // Проверяет наличие нужного объекта в массиве Slots
                {
                    FlagGarda = true;
                }
            }
           
        }

    }

}
