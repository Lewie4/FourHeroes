using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [System.Serializable]
    public class Stats
    {
        public float health;
        public float strength;
        public float dexterity;
        public float intelligence;
        public float crit;
        public float dodge;
        public float block;
        public float attackSpeed;

        public Stats()
        {
        }

        public Stats(Stats stats)
        {
            health = stats.health;
            strength = stats.strength;
            dexterity = stats.dexterity;
            intelligence = stats.intelligence;
            crit = stats.crit;
            dodge = stats.dodge;
            block = stats.block;
            attackSpeed = stats.attackSpeed;
        }
    }

    public enum CurrentState
    {
        None,
        Ready,
        Moving,
        Attacking,
        Dead
    }

    [SerializeField] protected bool m_playerControlled;
    [SerializeField] protected Targetting m_targetting;
    [SerializeField] protected CharacterMovementController m_movementController;
    [SerializeField] protected CharacterWeaponController m_weaponControls;

    [SerializeField] protected Stats m_totalStats;    //Max current stats 
    [SerializeField] protected Stats m_currentStats;     //Stats to be used in combat

    protected CurrentState m_currentState;
    protected BaseCharacter m_target;
    protected float m_timeSinceLastAttack;

    private void Start()
    {
        SetupStats();
        SetupCurrentStats();
    }

    protected void ClearStats()
    {
        m_totalStats = new Stats();
    }

    protected virtual void SetupStats()
    {

    }

    protected void SetupCurrentStats()
    {
        m_currentStats = new Stats(m_totalStats);
    }

    public void StartCombat()
    {
        m_currentState = CurrentState.Ready;

    }

    private void Update()
    {
        if (m_currentState != CurrentState.None)
        {
            if (m_target == null)
            {
                m_currentState = CurrentState.Ready;
            }

            switch (m_currentState)
            {
                case CurrentState.Moving:
                    {
                        Move();
                        break;
                    }
                case CurrentState.Attacking:
                    {
                        Attack();
                        break;
                    }
                default:
                    {
                        Ready();
                        break;
                    }
            }
        }
    }

    protected void Ready()
    {
        if (m_target == null)
        {
            GetTarget();
        }

        if (TargetInRange())
        {
            m_currentState = CurrentState.Attacking;
        }
        else
        {
            m_currentState = CurrentState.Moving;
        }
    }

    protected void Move()
    {
        if (m_movementController != null)
        {
            m_movementController.Move(m_target.transform.position - transform.position);
        }

        if(TargetInRange())
        {
            m_currentState = CurrentState.Attacking;
            m_movementController.Move(Vector3.zero);
        }
    }

    protected void Attack()
    {
        if (!TargetInRange())
        {
            m_currentState = CurrentState.Moving;
            return;
        }

        m_timeSinceLastAttack += Time.deltaTime;

        if (CheckCanAttack())
        {
            m_weaponControls.Attack();
            m_target.TakeDamage(TryAttack());
        }
    }

    protected void GetTarget()
    {
        if (m_targetting != null)
        {
            m_target = m_targetting.GetTarget(transform.position, CombatController.Instance.GetOppositeGroup(m_playerControlled));
        }
    }

    protected bool TargetInRange()
    {
        return GetTargetDistance() <= GetAttackRange();
    }

    protected float GetTargetDistance()
    {
        return Vector3.Distance(transform.position, m_target.transform.position);
    }

    protected float GetAttackRange()
    {
        return 2f;
    }

    public float TryAttack()
    {
        m_timeSinceLastAttack -= m_currentStats.attackSpeed; //Keep any leftover time to not punish bad devices

        float totalDamage = CalculateDamage(); //TODO: Crit damage

        Debug.Log(gameObject.name + " did " + totalDamage + " damage to enemy" + m_target);

        return totalDamage;
    }

    private bool CheckCanAttack()
    {
        if (m_timeSinceLastAttack > m_currentStats.attackSpeed)
        {
            return true;
        }
        return false;
    }

    protected virtual float CalculateDamage()
    {
        return 0;
    }

    public void TakeDamage(float damage)
    {
        m_currentStats.health -= damage;

        if (m_currentStats.health <= 0)
        {
            m_currentStats.health = 0;
            Die();
        }
    }

    private void Die()
    {
        m_currentState = CurrentState.Dead;

        Debug.Log("<color=red>" + gameObject.name + " has died!</color>");
    }


#if UNITY_EDITOR
    [ContextMenu("Kill Hero")]
    public void DebugKillHero()
    {
        TakeDamage(m_currentStats.health);
    }
#endif

}
