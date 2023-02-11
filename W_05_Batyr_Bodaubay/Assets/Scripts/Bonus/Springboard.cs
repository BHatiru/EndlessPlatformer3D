using UnityEngine;

public class Springboard : MonoBehaviour
{
    public Gradient Gradient;
    private Material _playerMaterial;
    public float JumpForce;

    private void Start()
    {
        _playerMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void SetColor()
    {
        var timeValue = Mathf.Abs(Mathf.Sin(Time.time));
        _playerMaterial.color = Gradient.Evaluate(timeValue);
    }

    private void Update()
    {
        SetColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerMover = collision.collider.gameObject.GetComponent<PlayerMover>();
        if (playerMover != null)
        {
            playerMover.Jump(JumpForce);
        }
    }
}
