using UnityEngine;
using UnityEditor;

public class IngredientInstance : MonoBehaviour
{
    public IngredientData data;
    public GameObject popUpUI;

    private string m_description;
    private string m_name;
    private IngredientType m_type;
    private MeshRenderer mesh;
    private bool _mesh = true;
    private bool playerCollision = false;
    public bool gotIngredient = false;

    public void Start()
    {
        m_name = data.name;
        m_description = data.description;
        m_type = data.type;
        mesh = GetComponent<MeshRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerCollision)
            change();
    }
/*
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            popUpUI.SetActive(true);
            playerCollision = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            popUpUI.SetActive(false);
            playerCollision = false;
        }
    }
*/
    public void change()
    {
        if (_mesh == true)
        {
            mesh.enabled = false;
            _mesh = false;
            Debug.Log(m_name + " mesh off");
            gotIngredient = true;
        }
        else
        {
            mesh.enabled = true;
            _mesh = true;
            Debug.Log(m_name + " mesh on");
            gotIngredient = false;
        }
    }
}
