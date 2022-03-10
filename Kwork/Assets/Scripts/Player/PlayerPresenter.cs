using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Wallet wallet;
    [SerializeField] private PlayerStatsCounter playerStatsCounter;

    private PlayerModel playerModel;
    private PlayerInterfaceView playerInterfaceView;
    private PlayerCharacterView playerCharacterView;
    private TargetDetector targetDetector;

    private IPlayerState currentState;

    [Header("States")]
    private IPlayerMoveState moveState;
    private IPlayerAttackState attackState;
    private IPlayerState idleState;

    private void Awake()
    {
        targetDetector = new TargetDetector();
        moveState = new PlayerMoveState();
        attackState = new PlayerAttackState();
        idleState = new PlayerIdleState();
        playerStatsCounter.PlayerStatsCounterConstructor(gameObject);
        targetDetector.OnPositionDetected += DetectedPositionHandler;
        targetDetector.OnEnemyDetected += DetectedEnemy;
    }

    public void PresenterConstructor(PlayerModel playerModel, PlayerInterfaceView playerInterfaceView, PlayerCharacterView playerCharacterView)
    {
        this.playerModel = playerModel;
        this.playerInterfaceView = playerInterfaceView;
        this.playerCharacterView = playerCharacterView;
    }

    public void SetCharacter(in Character character)
    {
        var model = Instantiate(character.ModelObject);
        playerModel = model.GetComponent<PlayerModel>();
        playerModel.OnHealthChange += ChangeHealthHandler;
        playerCharacterView.PlayerCharacterViewConstructor(character.Animator, character.SpriteCharecter);
        weaponController.SetCurrentWeapon(character.Weapon);
    }

    private void Update()
    {
        if (GameState.StateGame != StateGame.GAME) return;

        targetDetector.TouchDetect();
        playerInterfaceView.MakeMoveCount(playerStatsCounter.CountMoves());

        if (currentState == null) return;
        currentState.DoAction();
    }

    private void OnDisable()
    {
        playerModel.OnHealthChange -= ChangeHealthHandler;
        targetDetector.OnPositionDetected -= DetectedPositionHandler;
        targetDetector.OnEnemyDetected -= DetectedEnemy;
    }

    public void ChangeHealthHandler(int health)
    {
        playerInterfaceView.HealthChange(health);
        playerCharacterView.HealthChange(health);
    }

    public void DetectedPositionHandler(Vector3 target)
    {
        if (playerModel == null) return;
        moveState.SetStateParams(gameObject, target, playerModel.MoveSpeed);
        SetState(moveState);
        MoveView();
    }
    
    public void DetectedEnemy(Enemy enemy)
    {
        attackState.SetStateParams(weaponController, enemy);
        attackState.OnEnemyDeath += EnemyDeathHandler;
        SetState(attackState);
    }

    public void EnemyDeathHandler()
    {
        attackState.OnEnemyDeath -= EnemyDeathHandler;
        wallet.IncreseCoins(1);
        SetState(idleState);
    }

    public void SetState(IPlayerState playerState)
    {
        if (currentState != null)
            currentState.CancelAction();
        currentState = playerState;
        currentState.Enter();
    }


    public void ApplyDamage(int amount)
    {
        playerModel.ApplyDamage(amount);
    }

    public void MakeShoot()
    {

    }

    public void MoveView()
    {
        playerCharacterView.Move();
    }
}
