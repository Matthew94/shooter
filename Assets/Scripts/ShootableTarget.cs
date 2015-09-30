using UnityEngine;
using System.Collections;

public class ShootableTarget : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int Health
    {

        get { return health; }

        private set
        {
            health = value;

            Debug.Log(string.Format("Health of {0} is {1}", name, health));

            if (health <= 0)
            {
                Die();
            }
        }
    }
    [SerializeField]
    private int pointsValue;

    public int Points 
    { 
        get { return pointsValue; } 
    }


    public AudioClip deathClip;

    void start()
    {
        pointsValue = 10;
    }

    /// <summary>
    /// Makes target take damage.
    /// 
    /// True if dead due to hit.
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>True if dead due to hit.</returns>
    public bool ReactToHit(int damage)
    {
        Health -= damage;

        return health <= 0 ? true : false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
