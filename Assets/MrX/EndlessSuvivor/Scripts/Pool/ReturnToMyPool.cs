using UnityEngine;


namespace MrX.EndlessSurvivor
{
    public class ReturnToMyPool : MonoBehaviour
    {
        public MyPool pool;
        public void OnDisable()
        {
            pool.AddToPool(gameObject);
        }
    }
}