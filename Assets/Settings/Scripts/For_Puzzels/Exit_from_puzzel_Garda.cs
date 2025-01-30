using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_from_puzzel_Garda : MonoBehaviour
{
    public static int AllCountPuzzels; // Количество всех элементов паззла
    public static int CountPiecePuzzels; // Количество поставленных на место элементов 
    public  int Level;
    public string Name;
    public GameObject FinalPuzzel;// Объект содержащий финальный паззл
    public GameObject Panel;

    private Inventory Inven; // Инвентарь 
    public GameObject[] Itemes; // Объект, который нужно добавить
    void Start()
    {
        AllCountPuzzels = FinalPuzzel.transform.childCount; // Считывание кол-ва всех кусочков паззла
        Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // Присваивает значения инвентаря игрока
    }
    void Update()
    {
        bool CheckObject = false; // Переменная для проверка
        for (int i = 0; i < 5; i++)
        {
            if (Inven.Slots[i].transform.Find(Name) == true) // Проверяет наличие нужного объекта в слоте
            {
                CheckObject = true;
            }

        }
        if ( AllCountPuzzels == CountPiecePuzzels  ) // Проверяет, все ли кусочки паззла поставлены на свое место
        {
            SceneManager.UnloadSceneAsync(Level); // Выключает сцену с паззлом
            if (CheckObject == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Inven.Slots[i].transform.Find("Metal(Clone)") == true) // Проверяет наличие нужного объекта в слоте
                    {
                        GameObject parentObject = Inven.Slots[i]; // Присваивает переменной слот, с нужным дочерним объектом
                        foreach (Transform child in parentObject.transform) // Данный цикл уничтожит каждый дочерний объект слота
                        {
                            Destroy(child.gameObject);// Уничтожает этот дочерний объект
                        }
                        Inven.Full[i] = false;
                        break;
                    }
                }
                Add_Object.AddToInventory(Inven, Itemes); // Если не найден, то добавляется в инвентарь
            }
        }
    }
    public static void AddElement()
    {
        CountPiecePuzzels++; //Добавляет к кол-ву поставленных паззлов
    }
    public static bool Exit() // Проверяет, собран ли паззл или нет
    {

        if (AllCountPuzzels == CountPiecePuzzels) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
