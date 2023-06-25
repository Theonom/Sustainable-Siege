using UnityEngine;

public class WallProperty : MonoBehaviour
{
    public int wallHP = 100;
    private bool isDestroyed = false;

    public void TakeDamage(int damage)
    {
        wallHP -= damage;
        Debug.Log(wallHP);
        if (wallHP <= 0)
        {
            isDestroyed = true;
            DestroyWall();
        }
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    private void DestroyWall()
    {
        // Destroy the wall object
        Destroy(gameObject);
    }
}
