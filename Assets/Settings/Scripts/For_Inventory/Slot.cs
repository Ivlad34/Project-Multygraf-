using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory Inven; // Инвентарь
    public int NumberOfSlot; // Номер слота
    void Start()
    {
        Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // Присваивает значения инвентаря игрока

    }
    void Update()
    {
        if (transform.childCount <= 0) // Проверка, заполнен 
        {
            Inven.Full[NumberOfSlot] = false; // Делает слот не заполненным
        }
    }
    // Дописать, как будут исчезать объекты из инвентаря
}
