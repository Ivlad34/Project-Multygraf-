using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Add_Object : MonoBehaviour
{

    public static void AddToInventory(Inventory Inven, GameObject[] Items) // ���������� �������� � ���� ���������
    {
        Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // ����������� ���������� �������� ���������
        for (int x = 0; x < Items.Length; x++) // ����� ��������
        {
            for (int i = 0; i < Inven.Slots.Length; i++) // ����� �����
            {
                if (Inven.Full[i] == false) // ��������, �������� ���� ��� ���
                {
                    Inven.Full[i] = true; // ��������� ���
                    Instantiate(Items[x], Inven.Slots[i].transform); //��������� ������� � ����
                    break;
                }
            }
        }
    }
}
