using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleAttack : MonoBehaviour
{
    public LayerMask enemyLayer;      // Layer chứa các GameObject có tag "enemy"
    public float interactionDistance = 10;
    [SerializeField] protected float distanceToEnemy;
    public float DistanceToEnemy { get => distanceToEnemy; }
    public float speed = 5f;


    [SerializeField] protected float nearestDistance;
    public float NearestDistance { get => nearestDistance; }
    [SerializeField] protected Transform castlePrefabs;
    [SerializeField] protected Transform attackTip;
    [SerializeField] protected float timeUpdate;
    Collider2D nearestCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUpdate > -0.5) timeUpdate -= Time.deltaTime;

        KiemTra();
    }

    private void KiemTra()
    {
        Collider2D nearestEnemyCollider = GetNearestEnemyCollider();

        if (nearestEnemyCollider != null)
        {
            // Thực hiện sự kiện khi gặp enemy gần nhất
            //Debug.Log("Nhân vật gặp enemy gần nhất!");
            
            if(timeUpdate <= 0)
            {
                AttackEnemy();
                timeUpdate = 0.5f;
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
        if (hitEnemies.Length == 0)
        {
            PlayerAnimation.isShooting = false;


        }
        nearestCollider = null;
        nearestDistance = Mathf.Infinity;

        // Duyệt qua danh sách các enemy gần nhất
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Tính khoảng cách từ nhân vật đến enemy
            distanceToEnemy = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distanceToEnemy < nearestDistance)
            {
                // Cập nhật enemy gần nhất và khoảng cách tới nó
                nearestDistance = distanceToEnemy;
                nearestCollider = enemyCollider;
            }


        }

        return nearestCollider;
    }

    protected virtual void AttackEnemy()
    {
        Transform bulletAttack = Instantiate(castlePrefabs);
        bulletAttack.transform.position = attackTip.transform.position;
        bulletAttack.gameObject.SetActive(true);

        Vector3 direction = nearestCollider.transform.position - bulletAttack.position;
        direction.Normalize();

        bulletAttack.transform.right = direction;

    }

 
}
