
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport_Player : MonoBehaviour
{
    public int level;  // ����� ������, �� ������� ����� ������������� 
    public Vector3 position; // ���������� ���������
    public Mesto pos;  // ������� ���������, ������� ����� ��������
    private Inventory InventoryLast; // ���������


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null)
        {
            pos.initial = position; // ������ ������ ���������

            InventoryLast = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // ����������� ���������� ���������
 
            DontDestroyOnLoad(InventoryLast); // �� ���������� ���������
            for(int i = 0; i < 5; i++)
            {
                if (InventoryLast.Slots[i].transform.Find("Rock_Final(Clone)") == true) // ���������, ���� �� � ���� ����� ������ ������
                {
                    GameObject ParentObject = InventoryLast.Slots[i]; // ����������� ���������� ������ Slots ������ � ��������� ���������
                    foreach (Transform child in ParentObject.transform) // ������ ���� ��������� ������ �������� ������ ParentObject
                    {
                        DontDestroyOnLoad(child.gameObject); 
                    }

                }
            }

            SceneManager.LoadScene(level); // �������� ��������� �������
        }
    }
}