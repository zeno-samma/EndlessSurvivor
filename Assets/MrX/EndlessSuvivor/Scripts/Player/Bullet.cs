using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1;//
        // [SerializeField] private float timeDestroy = 0.25f;

        // Update is called once per frame
        void Update()
        {
            MoveBullet();
        }
        void MoveBullet()
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}

