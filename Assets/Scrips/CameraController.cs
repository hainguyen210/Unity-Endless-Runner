
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        //gan gia tri cho khoang cach giua nhan vat va camera
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //di chuyen camera theo nhat vat va khoang cach
        transform.position = player.transform.position + offset;
    }
}
