using UnityEngine;
using System.Collections;

public interface IItem {
    void Pickup(Transform hand);
    void Use();
    void Drop();
}