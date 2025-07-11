using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1;//
        private Vector3 moveDirection;

        // Một hàm public để WeaponController có thể "ra lệnh"
        public void SetDirection(Vector3 newDirection)
        {
            moveDirection = newDirection;
        }
        // [SerializeField] private float timeDestroy = 0.25f;

        // Update is called once per frame
        void Update()
        {
            // Chỉ cần di chuyển theo hướng đã được thiết lập
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}

