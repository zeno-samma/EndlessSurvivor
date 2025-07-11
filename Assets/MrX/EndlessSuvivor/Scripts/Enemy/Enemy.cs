using System;
using MRX.DefenseGameV1;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MrX.EndlessSurvivor
{
    public class Enemy : MonoBehaviour
    {
        public float speed;//Private sẽ không chạy  
        [SerializeField] public int maxHealth;
        private int currentHealth;
        public int minCoinBonus;
        public int maxCoinBonus;
        private Rigidbody2D m_rb;
        private Animator m_anim;
        private bool m_canMove = true;
        private bool isDead;
        public bool IsComponentNull()
        {
            return m_rb == null;
        }
        private void OnEnable()
        {
            currentHealth = maxHealth;
            m_canMove = true;
            if (m_anim != null)
            {
                // m_anim.SetBool(Const.ATTACK_ANIM, false);
            }
            // ===========================================================
            float ranX = Random.Range(-14, 14);
            float ranY = Random.Range(-8, 8);
            transform.position = new Vector3(ranX, ranY, 0f);
            // Kiểm tra để chắc chắn EnemyManager tồn tại trước khi đăng ký
            if (EnemyManager.Ins != null)
            {
                // Tự thêm chính mình (this) vào danh sách của Manager
                EnemyManager.Ins.RegisterEnemy(this);
            }
        }
        private void OnDisable()
        {
            // Kiểm tra để chắc chắn EnemyManager vẫn còn tồn tại
            if (EnemyManager.Ins != null)
            {
                // Tự xóa mình khỏi danh sách của Manager
                EnemyManager.Ins.UnregisterEnemy(this);
            }
        }
        private void Start()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {


        }
        // Hàm này sẽ được EnemyManager gọi
        public void Move(Vector3 direction)
        {
            if (m_canMove)
            {
                // Di chuyển theo hướng được chỉ định bởi Manager
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        void OnTriggerEnter2D(Collider2D colTarget)
        {
            if (IsComponentNull() || isDead) return;
            Debug.Log("colTarget" + colTarget.gameObject.name);
            if (colTarget.gameObject.CompareTag(Const.PLAYER_TAG) && !isDead)//So sánh va chạm tag player
            {
                m_canMove = false;
                // m_anim.SetBool(Const.ATTACK_ANIM, true);

            }
        }
        // private void OnCollisionStay2D(Collision2D colTarget)
        // {

        // }
        /// Trả về tỷ lệ máu hiện tại (từ 0.0 đến 1.0).
        public float GetHealthPercentage()
        {
            // Tránh lỗi chia cho 0 nếu maxHealth chưa được thiết lập
            if (maxHealth <= 0) return 0;

            return (float)currentHealth / maxHealth;
        }
        // Phương thức nhận sát thương từ bên ngoài
        public void TakeDamage(int damage)
        {
            // Debug.Log("TakeDamage: " + damage);
            if (currentHealth <= 0) return; // Nếu đã chết rồi thì không nhận thêm sát thương

            currentHealth -= damage;
            // Debug.Log("currentHealth " + currentHealth);
            // Đảm bảo máu không âm
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            // Tính toán tỷ lệ máu còn lại
            // float healthPercentage = (float)currentHealth / maxHealth;
            // Debug.Log("currentHealth " + healthPercentage);
            // Phát event cho UI
            // OnHealthChanged?.Invoke(healthPercentage);

            // Kiểm tra nếu đã chết
            if (currentHealth == 0)
            {
                int coinBonus = UnityEngine.Random.Range(minCoinBonus, maxCoinBonus);
                // EventBus.Publish(new EnemyDiedEvent { dieScore = coinBonus });
                // Debug.Log("Chết");
                gameObject.SetActive(false);
            }
        }
    }
}
