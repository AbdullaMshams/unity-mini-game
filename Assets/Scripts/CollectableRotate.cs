using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

[SerializeField] float rotationSpeed = 0.8f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);

    }
}
