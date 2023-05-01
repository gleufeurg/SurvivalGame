using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/New Item")]
public class ItemData : ScriptableObject
{
    public string name;
    public string description;
    public Sprite visual;
    public GameObject prefab;
}
