using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class WeaponAim : MonoBehaviour
    {
        private Camera mainCam;
        private Vector3 mousePos;

        void Start()
        {
            mainCam = Camera.main; // Lấy camera chính của game
        }

        void Update()
        {
            // 1. Lấy vị trí chuột trên màn hình
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            // 2. Tính toán hướng từ vũ khí đến con trỏ chuột
            Vector3 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 3. Xoay vũ khí theo góc đã tính
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // 4. Lật vũ khí để không bị lộn ngược
            Vector3 localScale = new Vector3(2,2,2);
            if (angle > 90 || angle < -90)
            {
                localScale.y = -2f; // Lật theo trục Y
            }
            else
            {
                localScale.y = 2f;
            }
            transform.localScale = localScale;
        }
    }
}

