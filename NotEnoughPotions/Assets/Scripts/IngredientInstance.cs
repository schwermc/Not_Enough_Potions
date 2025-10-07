using UnityEngine;

public class IngredientInstance : MonoBehaviour
{
    public IngredientData data;
    public GameObject popUpUI;

    private string m_description;
    private string m_name;
    private IngredientType m_type;
    private MeshRenderer mesh;
    private bool _mesh = true;
    public bool gotIngredient = false;

    public void Start()
    {
        m_name = data.name;
        m_description = data.description;
        m_type = data.type;
        mesh = GetComponent<MeshRenderer>();
    }

    public void change() {
        if (_mesh == true)
        {
            mesh.enabled = false;
            _mesh = false;
            Debug.Log(m_name + " mesh off");
            gotIngredient = true;
        }
    }
}
