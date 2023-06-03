using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    
    // Start is called before the first frame update
    public void Spawn()
    {
        Instantiate(ball, new Vector3(0f, 1f, -8f), Quaternion.identity);
    }
}
