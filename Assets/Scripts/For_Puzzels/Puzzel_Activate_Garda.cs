using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzel_Activate_Garda : MonoBehaviour
{
    public GameObject[] del; //Массив объектов, которым нужно будет отключать Collider
    public int level; //Номер сцены, которую нужно загрузить

    private BoxCollider2D Colid; //Collider предмета, который нужно удалить
    private CapsuleCollider2D ColidPlayer; //Collider игрока
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null && (Puzzel_Activate_Metal.FlagGarda == true) )  //Проверка, находится ли игрок в Collider нужного объекта и нажал ли игрок нужную клавишу
        {
            if (SceneManager.loadedSceneCount == 1 ) //Проверка кол-ва загруженных на данный момент сцен, для избежания моментов, когда по нажатию кнопки появляется несколько доп. экранов
            {
                Colid = del[0].GetComponent<BoxCollider2D>(); // Присваивание переменной, нужный BoxCollider
                Colid.enabled = false; // ВключениеBoxCollider объекта

                //ColidPlayer = del[1].GetComponent<CapsuleCollider2D>();
                //ColidPlayer.enabled = false;
                del[1].SetActive(false);

                 SceneManager.LoadScene(level, LoadSceneMode.Additive); // Загрузка сцены с паззлом по вер основного экрана

                if (Exit_from_puzzel_Rock.Exit() == true ) // Проверка, собран ли паззл
                {
                        SceneManager.UnloadSceneAsync(level); // Отключает экран с паззлом
                }
            }
        }
    }
    void Update()
    {
        if (SceneManager.loadedSceneCount == 2) // Проверка, запущены 
        {
            if (Exit_from_puzzel_Garda.Exit() == true ) // Паззл собран
            {
                //for (int i = 0; i < del.Length - 1; i++) // Цикл, для отключения BoxCollider объектов
                //{
                //Colid = del[0].GetComponent<BoxCollider2D>(); // Присваивание переменной, нужный BoxCollider
                ///Colid.enabled = true; // ВключениеBoxCollider объекта
                //}
                //ColidPlayer = del[1].GetComponent<CapsuleCollider2D>();
                //ColidPlayer.enabled = true;
                del[1].SetActive(true);
            }
        }
    }
}   


    

