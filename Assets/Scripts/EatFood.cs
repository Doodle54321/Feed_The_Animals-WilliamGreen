/*

Target GameObject: Animal Prefab

Description: Manages the eating behavior of an animal. In the Hungry state, the animal can eat food upon collision matching its preferred food type, transitioning it to Not Hungry where further food collisions are ignored.
*/

using UnityEditor.Build.Content;
using UnityEngine;

public class EatFood : MonoBehaviour
{
[SerializeField] private string FoodItEats;
private bool IsHungry = true;

private void OnCollisionEnter(Collision collision)
{
    if (!IsHungry)
    {
        return;
    }

    if (collision.gameObject.name.Contains(FoodItEats))
    {
        Destroy(collision.gameObject);
        UIManager.Instance.ScoreUpdate(10);
        IsHungry = false;
    }
}
}