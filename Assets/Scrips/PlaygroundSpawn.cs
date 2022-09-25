using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundSpawn : MonoBehaviour
{
   
    public GameObject[] Playground; //Mảng các đoạn đường tạo sẵn
    Vector3 SpawnPoint;

    // Khởi tạo 5 đoạn đường khi trò chơi bắt đầu
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            // Tạo một đoạn đường trống (index = 0) đã tạo sẵn sau đó tạo các đoạn đường có chướng ngại
            if (i == 0)
            {
                Spawn(0);
            }
            else {
                Spawn(Random.Range(1, 3));
            }   
        }
    }
    public void Spawn(int index) {
        // Tạo đoạn đường mới tại điểm SpawnPoint
        GameObject temp = Instantiate(Playground[index], SpawnPoint, Quaternion.identity);
        SpawnPoint = temp.transform.GetChild(3).transform.position;
    }
}
