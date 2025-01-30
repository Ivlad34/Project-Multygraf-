using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_from_puzzel_Garda : MonoBehaviour
{
    public static int AllCountPuzzels; // ���������� ���� ��������� ������
    public static int CountPiecePuzzels; // ���������� ������������ �� ����� ��������� 
    public  int Level;
    public string Name;
    public GameObject FinalPuzzel;// ������ ���������� ��������� �����
    public GameObject Panel;

    private Inventory Inven; // ��������� 
    public GameObject[] Itemes; // ������, ������� ����� ��������
    void Start()
    {
        AllCountPuzzels = FinalPuzzel.transform.childCount; // ���������� ���-�� ���� �������� ������
        Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // ����������� �������� ��������� ������
    }
    void Update()
    {
        bool CheckObject = false; // ���������� ��� ��������
        for (int i = 0; i < 5; i++)
        {
            if (Inven.Slots[i].transform.Find(Name) == true) // ��������� ������� ������� ������� � �����
            {
                CheckObject = true;
            }

        }
        if ( AllCountPuzzels == CountPiecePuzzels  ) // ���������, ��� �� ������� ������ ���������� �� ���� �����
        {
            SceneManager.UnloadSceneAsync(Level); // ��������� ����� � �������
            if (CheckObject == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Inven.Slots[i].transform.Find("Metal(Clone)") == true) // ��������� ������� ������� ������� � �����
                    {
                        GameObject parentObject = Inven.Slots[i]; // ����������� ���������� ����, � ������ �������� ��������
                        foreach (Transform child in parentObject.transform) // ������ ���� ��������� ������ �������� ������ �����
                        {
                            Destroy(child.gameObject);// ���������� ���� �������� ������
                        }
                        Inven.Full[i] = false;
                        break;
                    }
                }
                Add_Object.AddToInventory(Inven, Itemes); // ���� �� ������, �� ����������� � ���������
            }
        }
    }
    public static void AddElement()
    {
        CountPiecePuzzels++; //��������� � ���-�� ������������ �������
    }
    public static bool Exit() // ���������, ������ �� ����� ��� ���
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
