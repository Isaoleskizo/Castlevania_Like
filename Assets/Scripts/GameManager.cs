using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int wave = 0;
    private bool gameOver = false;
    [SerializeField] private GameObject prefabWalkEnemy;
    [SerializeField] private GameObject prefabStaticEnemy;
    [SerializeField] private CharacterControler cc;

    private List<GameObject> enemies;

    private void Awake()
    {
        wave = 0;
        enemies = new();
    }

    private void Update()
    {
        if (!gameOver)
        {
            enemies.RemoveAll(s => s == null);
            if (enemies.Count == 0)
            {
                NewWave();
            }
            if(cc.GetHPs()<=0)
            {
                gameOver= true;
            }
        }
        else Debug.Log("Perdu");
    }


    private void SpawnEnemies()
    {
        for(int i=0; i < wave; i++) 
        {
            int x = Random.Range(0, 3);
            if(x==0)
            {
                GameObject enemy = Instantiate(prefabWalkEnemy,new Vector2(Random.Range(-12, -8), 0),Quaternion.identity);
                enemy.GetComponent<Enemy>().SetLeft(false);
                enemies.Add(enemy);
            }
            else if (x==1)
            {
                GameObject enemy = Instantiate(prefabWalkEnemy, new Vector2(Random.Range(8, 12), 0), Quaternion.identity);
                enemy.GetComponent<Enemy>().SetLeft(true);
                enemies.Add(enemy);
            }
            else
            {
                GameObject enemy = Instantiate(prefabStaticEnemy, new Vector2(Random.Range(-5,5), 0), Quaternion.identity);
                enemies.Add(enemy);
            }
        }
    }



    private void NewWave()
    {
        wave++;
        UIManager.Instance.UpdateBoard();
        SpawnEnemies();

    }
    public int GetWave()
    {
        return wave;
    }

}
