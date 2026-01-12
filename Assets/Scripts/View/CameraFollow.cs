using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothness = 1.5f;
    void Update()
    {
        Vector3 targetPos = new Vector3(player.position.x + 3, player.position.y + 1, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothness * Time.deltaTime);
    }
}
