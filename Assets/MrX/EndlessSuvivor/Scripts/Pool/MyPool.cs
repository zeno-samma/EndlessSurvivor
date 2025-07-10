using System.Collections.Generic;
using UnityEngine;

namespace MrX.EndlessSurvivor
{
    public class MyPool
    {
        private Stack<GameObject> stack = new Stack<GameObject>();
        private GameObject baseObj;
        private GameObject tmp;
        private ReturnToMyPool returnPool;

        public MyPool(GameObject baseObj)
        {
            this.baseObj = baseObj;
        }

        public GameObject Get(bool activeValue, Vector3 position)
        {
            // Debug.Log(position);
            if (baseObj == null)
            {
                return null;
            }
            while (stack.Count > 0)
            {
                tmp = stack.Pop();//
                if (tmp != null)
                {
                    tmp.SetActive(activeValue);
                    return tmp;
                }
                else
                {
                    // Debug.LogWarning($"game object with key {baseObj.name} has been destroyed!");
                }
            }
            tmp = GameObject.Instantiate(baseObj, position, Quaternion.identity);
            returnPool = tmp.AddComponent<ReturnToMyPool>();
            returnPool.pool = this;
            return tmp;
        }
        public void AddToPool(GameObject obj)
        {
            stack.Push(obj);
        }
    }

}
