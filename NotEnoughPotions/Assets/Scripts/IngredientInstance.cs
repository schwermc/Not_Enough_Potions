using UnityEngine;
using UnityEditor;

public class IngredientInstance : MonoBehaviour
{
    public IngredientData data;

    private string m_description;
    private string m_name;
    private IngredientType m_type;

    public void Start()
    {
        m_name = data.name;
        m_description = data.description;
        m_type = data.type;
        // Debug.Log(m_name + ", " + m_type + ", " + m_description);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Ingredinet info: " + m_name + ", " + m_type);
        }
    }
}
