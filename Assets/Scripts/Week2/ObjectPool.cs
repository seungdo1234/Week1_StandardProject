using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();
    public int poolSize = 300;
    private string tag = "Monster";

    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        pool.Add(tag, new List<GameObject>());
        AddPool();
    }

    public GameObject Get()
    {
        GameObject select = null;

        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.

        for (int i = 0; i < pool[tag].Count; i++)

        {
            if (!pool[tag][i].activeSelf)
            {
                select = pool[tag][i];
            }

            if (i == pool.Count - 1)
            {
                AddPool();
                select = pool[tag][i + 1];
            }
        }

        select.SetActive(true);

        return select;
    }

    private void AddPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pref = Instantiate(prefab);
            pool[tag].Add(pref);
        }
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        // 게임오브젝트를 deactive한다.
    }
}