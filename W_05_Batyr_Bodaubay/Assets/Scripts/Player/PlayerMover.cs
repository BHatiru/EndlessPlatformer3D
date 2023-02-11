using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Bonuses")]
    [SerializeField] private List<SpeedBonusModel> _activeBonuses;
    private List<SpeedBonusModel> _bonusesToRemove;
    [SerializeField] private List<JumpBonusModel> _activeBonusesJump;
    private List<JumpBonusModel> _bonusesToRemoveJump;

    [SerializeField] private float _bonusSpeed;
    [SerializeField] private float _bonusJumpForce = 1f;
    [SerializeField] private float      _speed;
    [SerializeField] private float      _jumpForce;
    [SerializeField] private float      _sphereRadius;
    [SerializeField] private LayerMask  _groundLayer;

    private Vector3 _velocity;
    private Rigidbody _rigidbody;
    private bool _isGrounded;

    void Start()
    {
        _velocity = Vector3.forward * _speed;
        _rigidbody = GetComponent<Rigidbody>();

        _activeBonuses = new List<SpeedBonusModel>();
        _bonusesToRemove = new List<SpeedBonusModel>();

        _activeBonusesJump = new List<JumpBonusModel>();
        _bonusesToRemoveJump = new List<JumpBonusModel>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump(_jumpForce);
        }

        if(_activeBonuses.Count > 0 || _activeBonusesJump.Count > 0)
        {
            CheckBonuses();
        }
    }

    private void CheckBonuses()
    {
        foreach(SpeedBonusModel bonusModel in _activeBonuses)
        {
            if(Time.time >= bonusModel.EndTime)
            {
                _bonusSpeed -= bonusModel.BonusSpeed;
                _bonusesToRemove.Add(bonusModel);
            }
        }
        foreach(JumpBonusModel bonusModel in _activeBonusesJump)
        {
            if(Time.time >= bonusModel.EndTime)
            {
                _bonusJumpForce -= bonusModel.BonusJumpForce;
                _bonusesToRemoveJump.Add(bonusModel);
            }
        }

        foreach (SpeedBonusModel bonusModel in _bonusesToRemove)
        {
            _activeBonuses.Remove(bonusModel);
        }
        foreach (JumpBonusModel bonusModel in _bonusesToRemoveJump)
        {
            _activeBonusesJump.Remove(bonusModel);
        }

        _bonusesToRemove.Clear();
    }

    public void Jump(float jumpForce)
    {
        if(_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce * _bonusJumpForce, ForceMode.Impulse);
        }
    }

    public void AddSpeedBonus(SpeedBonusModel bonusModel)
    {
        
        bonusModel.EndTime = Time.time + bonusModel.Duration;

        
        _bonusSpeed += bonusModel.BonusSpeed;

        
        _activeBonuses.Add(bonusModel);
    }
    public void AddJumpBonus(JumpBonusModel bonusModel)
    {
        
        bonusModel.EndTime = Time.time + bonusModel.Duration;

        
        _bonusJumpForce += bonusModel.BonusJumpForce;

        
        _activeBonusesJump.Add(bonusModel);
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition = transform.position + _velocity * Time.fixedDeltaTime * _bonusSpeed;
        nextPosition.y += _rigidbody.velocity.y * Time.fixedDeltaTime;

        _isGrounded = Physics.CheckSphere(transform.position, _sphereRadius, _groundLayer.value);

        _rigidbody.MovePosition(nextPosition);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _sphereRadius);
    }
}