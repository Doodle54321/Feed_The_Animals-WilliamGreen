/*

GameObject: Player

Description: Handles selecting and throwing food prefabs based on Player Input and plays associated audio.
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
[SerializeField] private GameObject[] foodItems;
private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}

// Called by: Player Input
public void OnThrowFoodInput(InputAction.CallbackContext ctx)
{
    Debug.Log($"Pressed mouse{ctx.performed}");
    if (ctx.performed)
    {
        string controlName = ctx.control.name;
        SelectFood(controlName);
    }
}

private void SelectFood(string keyName)
{
    int index = 0;

    if(keyName == "q") index = 0;
    if(keyName == "w") index = 1;
    if(keyName == "e") index = 2;


    ThrowFood(index);
}

private void ThrowFood(int index)
{
    if (foodItems == null || foodItems.Length == 0 || index < 0 || index >= foodItems.Length)
    {
        return;
    }

    GameObject spawnedFood = Instantiate(foodItems[index], transform.position + Vector3.up, Quaternion.identity);

    if (audioSource != null && audioSource.clip != null)
    {
        audioSource.Play();
    }

    Rigidbody rb = spawnedFood.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }
}
}
