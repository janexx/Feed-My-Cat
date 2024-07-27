using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // Get half width of the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // move food forward
        transform.Translate(speed * Time.deltaTime * Vector3.back, Space.World);

        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
