using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory Inven; // ���������
    public int NumberOfSlot; // ����� �����
    void Start()
    {
        Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // ����������� �������� ��������� ������

    }
    void Update()
    {
        if (transform.childCount <= 0) // ��������, �������� 
        {
            Inven.Full[NumberOfSlot] = false; // ������ ���� �� �����������
        }
    }
    // ��������, ��� ����� �������� ������� �� ���������
}
