using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float acceleration;
    private Vector3 movementX;
    private Vector3 movementZ;
    public float jumpForce;
    public LayerMask ground;
    bool isGrounded;
    float horizontalInput;

    public TextMeshProUGUI countText;
    private int count;
    private bool collide;
    public GameObject gameOverPanel;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //khoi tao rigidbody va toc do
        rb = GetComponent<Rigidbody>();
        speed = 5;
        acceleration = 0.1f;

        count = 0;
        countText.text = "Score: " + count.ToString();

        collide = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            FindObjectOfType<Audio>().PlaySound("PickUp");
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Jump();
        }
        //lay chieu cao theo collider box cua nhan vat
        float height = GetComponent<Collider>().bounds.size.y;
        //bien kiem tra xem nhan vat co dung tren mat dat khong
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, ground);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void Jump() {
        
        
       

        //neu dung tren mat dat thi nhay
        if (isGrounded) {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    public void Lose() {
        collide = true;
        gameOverPanel.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (collide) return;

        //Toc do tang dang theo thoi gian
        if (speed < 100) {
            speed += acceleration * Time.fixedDeltaTime;
        }

        //Tinh toan di chuyen ve phia truoc nhan vat theo truc X
        movementX = transform.forward * speed * Time.fixedDeltaTime;

        //Tinh toan di chuyen theo chieu ngang tuong ung voi gia tri input
        movementZ = transform.right * horizontalInput * speed * Time.fixedDeltaTime * 2;

        //Di chuyen nhan vat
        rb.MovePosition(rb.position + movementX + movementZ);
    }

}