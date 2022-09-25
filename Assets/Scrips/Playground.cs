using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    PlaygroundSpawn playgroundSpawn;

    void Start()
    {
        playgroundSpawn = GameObject.FindObjectOfType<PlaygroundSpawn>();
    }

    private void OnTriggerExit(Collider other)
    {
        // Tạo thêm đường phía trước
        playgroundSpawn.Spawn(Random.Range(1,3));
        // Xóa bớt đường phía sau
        Destroy(gameObject, 2);
    }
}
