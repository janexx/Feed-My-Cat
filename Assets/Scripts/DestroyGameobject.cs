using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    private float zDestroyCoordinate = -10;

    // Update is called once per frame
    void Update()
    {
        // Detsroy this Gameobject when it reaches the defined z transform value
        if (transform.position.z < zDestroyCoordinate)
        {
            Destroy(gameObject);
        }
    }
}
