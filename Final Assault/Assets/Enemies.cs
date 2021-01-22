using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [SerializeField] GameObject Explosion;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }


    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.scoreHit();
        GameObject storingExplosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        storingExplosion.transform.parent = parent;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
