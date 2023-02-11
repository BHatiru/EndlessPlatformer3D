using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _safeBoundsZ;
    [SerializeField] private MeshRenderer _meshRenderer;

    public float GetSize()
    {
        return _meshRenderer.bounds.size.z - _safeBoundsZ;
    }

    public float GetHeight()
    {
        return _meshRenderer.bounds.size.y / 2;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 size = _meshRenderer.bounds.size;
        size.z = GetSize();

        Gizmos.DrawWireCube(_meshRenderer.bounds.center, size);
    }
}
