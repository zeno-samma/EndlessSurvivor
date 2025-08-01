using UnityEngine;

namespace MrX.EndlessSurvivor
{
    [RequireComponent(typeof(Rigidbody2D))] // Đảm bảo đối tượng luôn có Rigidbody2D
    public class PlayerMovement : MonoBehaviour,IsComponentChecking
    {
        public PlayerConfigSO playerConfig; // Biến để chứa file config của người chơi

        private Rigidbody2D rb; // Để xử lý vật lý
        private Animator m_anim;
        private Vector2 moveInput; // Để lưu trữ giá trị input (x, y)

        public bool IsComponentNull()
        {
            return m_anim == null || rb == null || playerConfig == null ;
        }
        void Awake()
        {

            // Lấy component Rigidbody2D gắn trên cùng đối tượng
            rb = GetComponent<Rigidbody2D>();
            m_anim = GetComponent<Animator>();
            // KIỂM TRA NULL
            if (IsComponentNull())
            {
                Debug.LogError("Lỗi chưa được gán trong Inspector!", this.gameObject);
                return;
            }
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Đọc input trong Update vì nó chạy mỗi frame, phản hồi nhanh
            float moveX = Input.GetAxisRaw("Horizontal"); // Trục ngang (A, D, <-, ->)
            float moveY = Input.GetAxisRaw("Vertical");   // Trục dọc (W, S, up, down)

            moveInput = new Vector2(moveX, moveY).normalized;// .normalized giúp nhân vật không bị đi nhanh hơn khi đi chéo
            // Gửi thông số di chuyển vào Animator
            // Animator sẽ tự quyết định chạy animation nào dựa trên Blend Tree
            if (moveInput != Vector2.zero)
            {
                m_anim.SetBool("isMoving", true); // Bật nếu bạn có state Idle
                m_anim.SetFloat("moveX", moveInput.x);
                m_anim.SetFloat("moveY", moveInput.y);
            }
            else if (moveInput == Vector2.zero)
            {
                m_anim.SetBool("isMoving", false); // Bật nếu bạn có state Idle 
            }

        }
        void FixedUpdate()
        {
            // Áp dụng lực di chuyển trong FixedUpdate vì nó đồng bộ với vòng lặp vật lý
            // Di chuyển bằng cách thay đổi vận tốc của Rigidbody
            rb.linearVelocity = moveInput * playerConfig.initialMoveSpeed;
        }
    }
}

