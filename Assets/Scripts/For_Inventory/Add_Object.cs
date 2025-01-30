using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Add_Object : MonoBehaviour
{

    public static void AddToInventory(Inventory Inven, GameObject[] Items) // Добавление предмета в слот инвентаря
    {
        Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // Присваивает переменной значение инвентаря
        for (int x = 0; x < Items.Length; x++) // Номер предмета
        {
            for (int i = 0; i < Inven.Slots.Length; i++) // Номер слота
            {
                if (Inven.Full[i] == false) // Проверка, заполнен слот или нет
                {
                    Inven.Full[i] = true; // Заполняет его
                    Instantiate(Items[x], Inven.Slots[i].transform); //Добавляет предмет в слот
                    break;
                }
            }
        }
    }
}
