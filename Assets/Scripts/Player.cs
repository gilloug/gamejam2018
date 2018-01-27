using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public class Resetable<T>
    {
        private T backup;
        public T origin;
        public T current;
        public Resetable(T f)
        {
            backup = f;
            to_backup();
            to_origin();
        }
        public void to_origin()
        {
            current = origin;
        }
        public void to_backup()
        {
            origin = backup;
        }
    }

    //Physics
    private float jump_velocity = 20f;
    private float move_velocity = 20f;

    //Config
    public Resetable<float> damage_multiplicator = new Resetable<float>(1f);
    public Resetable<float> disable_time = new Resetable<float>(5f);
    public Resetable<float> health = new Resetable<float>(50f);
    public Resetable<int> jump_count = new Resetable<int>(2);
    public Resetable<float> weapon_cooldown;
    public GameObject weapon;

    //Internal variables
    private Rigidbody2D body;
    private Collider2D coll;
    private int wall_layer;
    private Weapon weapon_script;
    private List<GameObject> active_items = new List<GameObject>();
    private List<GameObject> passive_items = new List<GameObject>();

    private bool disabled = false;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        wall_layer = 1 << LayerMask.NameToLayer("Wall");
        weapon_script = weapon.GetComponent<Weapon>();
        weapon_cooldown = new Resetable<float>(weapon_script.get_cooldown());
    }

    void update_movement()
    {
        if (Physics2D.Raycast(new Vector2(coll.bounds.center.x, coll.bounds.min.y), Vector2.down, 0.1f, wall_layer).collider)
        {
            jump_count.to_origin();
        }
        float x_speed = body.velocity.x + Input.GetAxis("Horizontal") * move_velocity * Time.deltaTime;
        float y_speed = body.velocity.y;
        if (jump_count.current > 0 && Input.GetKeyDown("joystick button 5"))
        {
            jump_count.current--;
            y_speed = jump_velocity;
        }
        body.velocity = new Vector2(x_speed, y_speed);
    }

    void update_fire()
    {
        if (disabled)
            return;
        Vector2 fire_direction = new Vector2(Input.GetAxis("R-Horizontal"), -Input.GetAxis("R-Vertical"));
        if (weapon_cooldown.current > 0)
        {
            weapon_cooldown.current -= Time.deltaTime;
        }
        else if (fire_direction.magnitude > 0.01)
        {
            weapon_script.use(gameObject, fire_direction.normalized);
            weapon_cooldown.to_origin();
        }
    }

    public void take_damage(float damage)
    {
        if (disabled)
            return;
        health.current -= damage;
        if (health.current > 0)
        {
            return;
        }
        disable();
        to_backup();
        ItemManager.Spawn(active_items.ToArray(), transform);
        ItemManager.Spawn(passive_items.ToArray(), transform);
        active_items.Clear();
        passive_items.Clear();
    }

    public void disable()
    {
        disabled = true;
        health.to_origin();
        disable_time.to_origin();
    }

    void update_disable()
    {
        if (!disabled)
        {
            return;
        }
        if (disable_time.current > 0)
        {
            disable_time.current -= Time.deltaTime;
            return;
        }
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        update_disable();
        update_movement();
        update_fire();
    }

    void to_backup()
    {
        damage_multiplicator.to_backup();
        disable_time.to_backup();
        health.to_backup();
        jump_count.to_backup();
        weapon_cooldown.to_backup();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (disabled)
        {
            return;
        }
        GameObject obj = coll.gameObject;
        if (obj.layer != LayerMask.NameToLayer("Item"))
        {
            return;
        }
        obj.SetActive(false);
        Item item = obj.GetComponent<Item>();
        if (item.is_active())
        {
            active_items.Add(obj);
        }
        else
        {
            passive_items.Add(obj);
            item.update_player(this);
        }
    }
}