
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Neu va cham voi nhan vat thi goi toi ham lose()
        if (collision.gameObject.name == "Player")
        {
            playerController.Lose();
        }
    }
}
