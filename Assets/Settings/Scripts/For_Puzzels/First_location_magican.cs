using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_location_magican : MonoBehaviour
{
    private Inventory Inven; // ��������� 
    private int PeaceOfStick = 0;
    private static bool HaveStick = false;

    public CircleCollider2D Teleport;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player2D>() != null && Input.GetKey(KeyCode.E) == true) //��������, ��������� �� ����� � Collider ������� �������
        {
            Inven = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Inventory>(); // ����������� �������� ��������� ������
            for (int i = 0; i < 5; i++)
            {
                if (Inven.Slots[i].transform.Find("Cristal(Clone)") || Inven.Slots[i].transform.Find("Garda(Clone)") || Inven.Slots[i].transform.Find("Stick(Clone)") ) 
                {
                    GameObject parentObject = Inven.Slots[i]; // ����������� ���������� ����, � ������ �������� ��������
                    foreach (Transform child in parentObject.transform) // ������ ���� ��������� ������ �������� ������ �����
                    {
                        Destroy(child.gameObject);// ���������� ���� �������� ������
                        PeaceOfStick++;
                    }
                    Inven.Full[i] = false;
                }
                if (PeaceOfStick == 3) // ��������� ������� ������� ������� � ������� Slots
                {
                    HaveStick = true;
                    break;
                }
            }

        }

    }
    private void Update()
    {
        if (HaveStick == true)
        {
            Teleport.enabled = true;
        }
    }
}
