using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTurret : Construction
{
    [Header("Gameplay Variables")]
    public float attackSpeed_;
    public float attackDamage_;
    public float range_;
    public float rotationSpeed_;
    public float bulletSpeed;

    [Header("Dependencies")]
    public GameObject bullet_;
    public CustomCrapyAnimation anim;
    public Animator animator;
    public Transform position_of_gun_;


    [Header("Debug")]
    [SerializeField] private List<Enemy> enemy_buffer_;
    public Enemy target_ = null;

    private bool there_are_enemies_to_shoot = false;
    private bool can_shoot_ = true;
    private float attackAnimationTime;

    // Start is called before the first frame update
    void Start()
    {
        enemy_buffer_ = new List<Enemy>();
        if (animator != null)
        {
            animator.SetBool("growing", true);
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                switch (clip.name)
                {
                    case "attack":
                        attackAnimationTime = clip.length;
                        break;
                }
            }

            animator.SetFloat("attackSpeed", attackAnimationTime / attackSpeed_);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * range_);

        LookForTargets();
        there_are_enemies_to_shoot = (enemy_buffer_.Count > 0);
        if (animator != null)
        {
            if (there_are_enemies_to_shoot) animator.SetBool("attacking", true);
            else animator.SetBool("attacking", false);
        }
        SetTarget();

        if (target_ != null)
        {
            //rotate
            Quaternion lookTarget = Quaternion.LookRotation((target_.transform.position - transform.position).normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * rotationSpeed_);

            //transform.LookAt(target_.transform);
            if ((target_.transform.position - position_of_gun_.position).magnitude > range_)
            {
                UnlinkTarget();
            }
        }

        if (can_shoot_ && there_are_enemies_to_shoot && target_ != null)
        {
            StartCoroutine(ShootTarget());
        }

        GarbageCollector();
    }

    IEnumerator ShootTarget()
    {
        can_shoot_ = false;
        GameObject go = Instantiate(bullet_, position_of_gun_.position, Quaternion.identity);

        go.GetComponent<Rigidbody>().AddForce(bulletSpeed * (target_.transform.position - position_of_gun_.position).normalized, ForceMode.Impulse);
        go.GetComponent<Bullet>().target_ = target_;
        go.GetComponent<Bullet>().hit((int)attackDamage_);

        if (anim != null)
            anim.attack();
        yield return new WaitForSeconds(attackSpeed_);
        can_shoot_ = true;

    }

    void LookForTargets()
    {
        Collider[] hitinfo = Physics.OverlapSphere(position_of_gun_.position, range_);
        if (hitinfo != null)
        {

            foreach (var hitCollider in hitinfo)
            {
                Enemy tmp = hitCollider.gameObject.GetComponent<Enemy>();
                if (tmp != null)
                {

                    if (!enemy_buffer_.Contains(tmp))
                    {
                        enemy_buffer_.Add(tmp);
                    }

                }
            }
        }
    }

    void SetTarget()
    {
        if (target_ == null && there_are_enemies_to_shoot)
        {
            target_ = enemy_buffer_[0];
            target_.shooting_tower_ = this;
        }
    }

    public void UnlinkTarget()
    {
        target_ = null;
        if (enemy_buffer_.Count > 0)
            enemy_buffer_.RemoveAt(0);
    }

    void GarbageCollector()
    {
        for (int i = 0; i < enemy_buffer_.Count; ++i)
        {
            if (enemy_buffer_[i] == null)
            {
                enemy_buffer_.RemoveAt(i);
            }
        }
    }
}
