/*

GameObject: Animal Prefab

Description: Manages the eating behavior of an animal, allowing it to eat food upon collision while hungry, transitioning to a not hungry state after consuming food, and ignoring further food collisions.
*/

using UnityEngine;

public class EatFood : MonoBehaviour
{
[SerializeField] private string FoodItEats;
private bool IsHungry = true;

private void OnCollisionEnter(Collision collision)
{
    if (IsHungry && collision.gameObject.CompareTag(FoodItEats))
    {
        Destroy(collision.gameObject);
        IsHungry = false;
    }
}
}