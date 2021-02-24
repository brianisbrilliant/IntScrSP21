using UnityEngine;

public interface IItem {
    void Pickup(Transform hand);
    void Use();
    void Drop();
}