using UnityEngine;

public class DrawCollider : MonoBehaviour
{
#if UNITY_EDITOR

    public Color m_gizmo = new Color(1.0f, 0.0f, 0.0f, 0.7f);
    public Collider m_myCollider;

    public void OnDrawGizmos()
    {
        if (m_myCollider == null)
            return;
        if (m_myCollider.enabled == false)
            return;
        DrawBoxCollider(m_gizmo, m_myCollider as BoxCollider);
    }
    private void DrawBoxCollider(Color gizmoColor, BoxCollider boxCollider, float alphaForInsides = 0.3f)
    {

        var color = gizmoColor;

        Gizmos.matrix = Matrix4x4.TRS(this.transform.TransformPoint(boxCollider.center), this.transform.rotation, this.transform.lossyScale);

        Gizmos.color = color;
        Gizmos.DrawWireCube(Vector3.zero, boxCollider.size);


        color.a *= alphaForInsides;
        Gizmos.color = color;
        Gizmos.DrawCube(Vector3.zero, boxCollider.size);
    }
    [ContextMenu("Set Collider to Self")]
    private void SetColliderToSelf()
    {
        m_myCollider = GetComponent<Collider>();
        if (gameObject.CompareTag("Ground") || m_myCollider == null || m_myCollider.isTrigger)
        {
            DestroyImmediate(this);
        }
    }

#endif
}
