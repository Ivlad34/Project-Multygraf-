using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzel_Activate_Metal : MonoBehaviour
{
    public GameObject[] Rock;
    private Inventory Inven; // ��������� 

    public static bool FlagGarda = false;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null && Input.GetKey(KeyCode.E) == true) //��������, ��������� �� ����� � Collider ������� �������
        {
            Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // ����������� �������� ��������� ������
            for (int i = 0; i < 5; i++) 
            {
                if (Inven.Slots[i].transform.Find("Rock_Final(Clone)") == true) // ��������� ������� ������� ������� � ������� Slots
                {
                    GameObject parentObject = Inven.Slots[i]; // ����������� ���������� ����, � ������ �������� ��������
                    foreach (Transform child in parentObject.transform) // ������ ���� ��������� ������ �������� ������ �����
                    {
                        Destroy(child.gameObject);// ���������� ���� �������� ������
                    }
                    Inven.Full[i] = false;
                    Add_Object.AddToInventory(Inven, Rock); // ��������� ����� �������
                    break;
                }
                if (Inven.Slots[i].transform.Find("Metal(Clone)") == true) // ��������� ������� ������� ������� � ������� Slots
                {
                    FlagGarda = true;
                }
            }
           
        }

    }

}
