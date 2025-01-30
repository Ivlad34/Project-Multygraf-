using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]
public class Inventory : MonoBehaviour
{
    public bool[] Full; // Массив переменных, в которых записано, заполнены ячейки или нет
    public GameObject[] Slots; // Массив всех слотов
}
