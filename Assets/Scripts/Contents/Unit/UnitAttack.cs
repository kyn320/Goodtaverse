using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

public class UnitAttack : SerializedMonoBehaviour
{
    private UnitStatus unitStatus;

    public Transform attackPoint;

    public List<Animator> animatorList;

    [SerializeField]
    public Dictionary<int, AttackInfoData> attackDataDic = new Dictionary<int, AttackInfoData>();

    private int prevCombo;
    private AttackInfoData currentAttackInfo;
    private AttackHitBox currentHitBox;

    public UnityEvent startAttackEvent;
    public UnityEvent updateAttackEvent;
    public UnityEvent endAttackEvent;

    [SerializeField]
    private bool useAttackAnimation = true;

    private int currentHitCount = 0;
    public UnityEvent<int> hitCountUpdateEvent;

    private void Awake()
    {
        unitStatus = GetComponent<UnitStatus>();
    }

    public void Attack(int combo)
    {
        prevCombo = combo;
        currentHitCount = 0;
        currentAttackInfo = attackDataDic[combo];
        StartAttack();
    }

    public void Damage(Collider2D collider)
    {
        var damageAble = collider.GetComponent<IDamageable>();
        var damageAmount = unitStatus.currentStatus.CalculateDamage();

        Debug.Log("name : " + collider.gameObject.name + " | Damage : " + damageAmount);

        if (damageAble != null)
        {
            if (useAttackAnimation)
                CameraController.Instance.AnimateHit();

            ++currentHitCount;
            hitCountUpdateEvent?.Invoke(currentHitCount);

            var damagePoint = collider.ClosestPoint(currentHitBox.transform.position);

            var isKill = damageAble.OnDamage(damageAmount,
                damagePoint,
                Vector3.up);

            CheckKill(isKill);

            var damageVFX = ObjectPoolManager.Instance.Get(currentAttackInfo.damagedVfx.name);
            damageVFX.transform.position = damagePoint;
        }
    }

    public void Damage(Collider2D hitBox, Collider2D collider)
    {
        var damageAble = collider.GetComponent<IDamageable>();
        var damageAmount = unitStatus.currentStatus.CalculateDamage();

        Debug.Log("name : " + collider.gameObject.name + " | Damage : " + damageAmount);

        if (damageAble != null)
        {
            if (useAttackAnimation)
                CameraController.Instance.AnimateHit();

            ++currentHitCount;
            hitCountUpdateEvent?.Invoke(currentHitCount);

            var damagePoint = collider.ClosestPoint(hitBox.transform.position);

            var isKill = damageAble.OnDamage(damageAmount,
                damagePoint,
                Vector3.up);

            CheckKill(isKill);

            var damageVFX = ObjectPoolManager.Instance.Get(currentAttackInfo.damagedVfx.name);
            damageVFX.transform.position = damagePoint;
        }
    }

    private async void StartAttack()
    {
        AnimateTriggerDatas(currentAttackInfo.startTriggerList);
        startAttackEvent?.Invoke();
        await UniTask.Delay((int)(currentAttackInfo.waitForStartTime * 1000));
        UpdateAttack();
    }

    private async void UpdateAttack()
    {
        //TODO :: Create VFX

        if (currentAttackInfo.attackVfx == null)
            return;

        var attackVFX = ObjectPoolManager.Instance.Get(currentAttackInfo.attackVfx.name);
        var lookat = attackVFX.transform.rotation.eulerAngles;
        lookat.y = transform.rotation.eulerAngles.y;

        attackVFX.transform.position = attackPoint.position;
        attackVFX.transform.rotation = Quaternion.Euler(lookat);

        currentHitBox = attackVFX.GetComponent<AttackHitBox>();
        currentHitBox.triggerEnterEvent.AddListener(Damage);


        AnimateTriggerDatas(currentAttackInfo.updateTriggerList);
        var currentTime = currentAttackInfo.attackTime;

        while (currentTime >= 0)
        {
            updateAttackEvent?.Invoke();
            currentTime -= Time.deltaTime;
            await UniTask.DelayFrame(1);
        }

        EndAttack();
    }

    private async void EndAttack()
    {
        AnimateTriggerDatas(currentAttackInfo.endTriggerList);
        await UniTask.Delay((int)(currentAttackInfo.waitForEndTime * 1000));
        endAttackEvent?.Invoke();
    }

    protected void CheckKill(bool isKill)
    {
        if (!isKill)
            return;

    }

    private void AnimateTriggerDatas(List<AnimatorTriggerData> triggerDatas)
    {
        for (var i = 0; i < triggerDatas.Count; ++i)
        {
            for (var j = 0; j < animatorList.Count; ++j)
            {
                triggerDatas[i].Invoke(animatorList[j]);
            }
        }
    }

}
