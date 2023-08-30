using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private static PlayerShooting instance;
    public static PlayerShooting Instance { get => instance; }

    public LayerMask enemyLayer;      // Layer chứa các GameObject có tag "enemy"
    public float interactionDistance = 10;
    [SerializeField] protected float distanceToEnemy;
    public float DistanceToEnemy { get => distanceToEnemy; }


    [SerializeField] protected float nearestDistance;
    public float NearestDistance { get => nearestDistance; }
    [SerializeField] protected Transform bulletPrefabs;
    [SerializeField] protected Transform shootTip;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShooting.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        KiemTra();
    }

    public void Shooting()
    {
       
       Transform bulletArrow = Instantiate(this.bulletPrefabs,shootTip.transform.position,Quaternion.Euler(0,0,0));
       bulletArrow.gameObject.SetActive(true);

    }

    private void KiemTra()
    {
        Collider2D nearestEnemyCollider = GetNearestEnemyCollider();

        if (nearestEnemyCollider != null)
        {
            // Thực hiện sự kiện khi gặp enemy gần nhất
            //Debug.Log("Nhân vật gặp enemy gần nhất!");
            if(InputManager.Instance.Horizontal == 0)
            {
                
                PlayerAnimation.isShooting = true;
            }
            else
            {
                PlayerAnimation.isShooting = false;

            }


            // Ở đây, bạn có thể thực hiện animation hoặc hành động khác tùy theo yêu cầu của trò chơi
        }
        else
        {
            

        }
    }
    private Collider2D GetNearestEnemyCollider()
    {
        // Tìm các GameObject enemy nằm trong khoảng cách interactionDistance
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, interactionDistance, enemyLayer);
        if(hitEnemies.Length == 0)
        {
            PlayerAnimation.isShooting = false;


        }
        Collider2D nearestCollider = null;
        nearestDistance = Mathf.Infinity;

        // Duyệt qua danh sách các enemy gần nhất
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Tính khoảng cách từ nhân vật đến enemy
            distanceToEnemy = Vector2.Distance(transform.parent.position, enemyCollider.transform.position);

            if (distanceToEnemy < nearestDistance)
            {
                // Cập nhật enemy gần nhất và khoảng cách tới nó
                nearestDistance = distanceToEnemy;
                nearestCollider = enemyCollider;
            }

          
        }

        return nearestCollider;
    }
}
