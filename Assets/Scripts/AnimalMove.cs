/*

GameObject: Animal Prefab

Description: Controls the movement and life cycle of the Animal GameObject, moving it forward and removing it once it moves past the scene boundary.
*/

using UnityEngine;

public class AnimalMove : MonoBehaviour
{
[SerializeField] private float animalSpeed;
private float outOfScene;

private void Update()
{
    MoveForward();
    DeleteOutOfScene();
}

private void MoveForward()
{
    transform.Translate(Vector3.forward * animalSpeed * Time.deltaTime);
}

private void DeleteOutOfScene()
{
    if (transform.position.z > outOfScene)
    {
        Destroy(gameObject);
    }
}
}