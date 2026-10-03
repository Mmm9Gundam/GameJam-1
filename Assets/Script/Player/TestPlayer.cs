using UnityEngine;                                //测试使用！！！ 若有干扰请直接删除

/*
 * 功能：玩家移动 + 检测炮塔是否攻击
 * 挂载：玩家身上
 * 组件：Rigidbody2D (Gravity Scale=0)、Collider2D
 * Tag：Player
 */
public class PlayerController : MonoBehaviour
{
    [Header("移动")]
    public float moveSpeed = 5f;      // 移动速度

    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. 读取键盘输入（WASD 或 方向键）
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // 2. 用物理速度移动玩家
        rb.velocity = input.normalized * moveSpeed;
    }

    // 3. 检测炮塔/敌人是否攻击
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("被炮塔/敌人攻击了！");
        }
    }
}