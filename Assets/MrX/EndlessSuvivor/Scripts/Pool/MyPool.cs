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

        public GameObject Get(bool activeValue)
        {

            if (baseObj == null)
            {
                return null;
            }
            Debug.Log(stack.Count);
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
            tmp = GameObject.Instantiate(baseObj, new Vector3(14f, -8f, 0f), Quaternion.identity);
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
