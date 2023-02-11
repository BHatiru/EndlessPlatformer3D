using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public Gradient Gradient;
    public Slider HealthBar;
    private Material _playerMaterial;

    private float _maxHealth;
    [SerializeField] DeathBorder _deathBorder;

    private void Start()
    {
        _maxHealth = Health;
        _playerMaterial = GetComponent<MeshRenderer>().sharedMaterial;

        SetGradientColor();
    }

    private void SetGradientColor()
    {
        float normalizedValue = GetNormalizedHealth();
        _playerMaterial.color = Gradient.Evaluate(1 - normalizedValue);
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        SetSliderValue();
        SetGradientColor();

        if (Health <= 0)
        {
            Debug.Log("You are dead");
            _deathBorder.SaveScores();
            Death();
        }
    }

    public void AddHealth(float healValue)
    {
        Health += healValue;
        Health = Mathf.Clamp(Health, 0, _maxHealth);

        SetSliderValue();
        SetGradientColor();
    }

    private void SetSliderValue()
    {

        HealthBar.value = GetNormalizedHealth();
    }

    private float GetNormalizedHealth()
    {
        return Health / _maxHealth;
    }

    public void Death()
    {
        Health = 0;
        SetSliderValue();

        SceneManager.LoadScene(0);
    }
}
