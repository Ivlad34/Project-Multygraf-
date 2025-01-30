
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport_Player : MonoBehaviour
{
    public int level;  // Номер уровня, на который нужно переместиться 
    public Vector3 position; // Координаты персонажа
    public Mesto pos;  // Позиция персонажа, которую нужно записать
    private Inventory InventoryLast; // Инвентарь


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null)
        {
            pos.initial = position; // Запись нужных координат

            InventoryLast = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // Присваивает переменной инвентарь
 
            DontDestroyOnLoad(InventoryLast); // Не уничтожает инвентарь
            for(int i = 0; i < 5; i++)
            {
                if (InventoryLast.Slots[i].transform.Find("Rock_Final(Clone)") == true) // Проверяет, есть ли в этом слоте нужный объект
                {
                    GameObject ParentObject = InventoryLast.Slots[i]; // Присваивает переменной объект Slots вместе с дочерними объектами
                    foreach (Transform child in ParentObject.transform) // Данный цикл сохраняет каждый дочерний объект ParentObject
                    {
                        DontDestroyOnLoad(child.gameObject); 
                    }

                }
            }

            SceneManager.LoadScene(level); // Загрузка следующей локации
        }
    }
}