using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzel_Activate_Garda : MonoBehaviour
{
    public GameObject[] del; //������ ��������, ������� ����� ����� ��������� Collider
    public int level; //����� �����, ������� ����� ���������

    private BoxCollider2D Colid; //Collider ��������, ������� ����� �������
    private CapsuleCollider2D ColidPlayer; //Collider ������
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null && (Puzzel_Activate_Metal.FlagGarda == true) )  //��������, ��������� �� ����� � Collider ������� ������� � ����� �� ����� ������ �������
        {
            if (SceneManager.loadedSceneCount == 1 ) //�������� ���-�� ����������� �� ������ ������ ����, ��� ��������� ��������, ����� �� ������� ������ ���������� ��������� ���. �������
            {
                Colid = del[0].GetComponent<BoxCollider2D>(); // ������������ ����������, ������ BoxCollider
                Colid.enabled = false; // ���������BoxCollider �������

                //ColidPlayer = del[1].GetComponent<CapsuleCollider2D>();
                //ColidPlayer.enabled = false;
                del[1].SetActive(false);

                 SceneManager.LoadScene(level, LoadSceneMode.Additive); // �������� ����� � ������� �� ��� ��������� ������

                if (Exit_from_puzzel_Rock.Exit() == true ) // ��������, ������ �� �����
                {
                        SceneManager.UnloadSceneAsync(level); // ��������� ����� � �������
                }
            }
        }
    }
    void Update()
    {
        if (SceneManager.loadedSceneCount == 2) // ��������, �������� 
        {
            if (Exit_from_puzzel_Garda.Exit() == true ) // ����� ������
            {
                //for (int i = 0; i < del.Length - 1; i++) // ����, ��� ���������� BoxCollider ��������
                //{
                //Colid = del[0].GetComponent<BoxCollider2D>(); // ������������ ����������, ������ BoxCollider
                ///Colid.enabled = true; // ���������BoxCollider �������
                //}
                //ColidPlayer = del[1].GetComponent<CapsuleCollider2D>();
                //ColidPlayer.enabled = true;
                del[1].SetActive(true);
            }
        }
    }
}   


    

