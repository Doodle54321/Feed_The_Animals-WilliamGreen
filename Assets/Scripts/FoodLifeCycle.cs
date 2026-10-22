/*

GameObject: Food Prefab

Description: Manages the life cycle of the Food GameObject, allowing physics to act on it during its existence and destroying it after a specified life duration.
*/

using System.Collections;
using UnityEngine;

public class FoodLifeCycle : MonoBehaviour
{
[SerializeField] private float lifeDuration;

private void Start()
{
    StartCoroutine(DeleteAfterLifeDuration());
}

private IEnumerator DeleteAfterLifeDuration()
{
    yield return new WaitForSeconds(lifeDuration);
    Destroy(gameObject);
}
}