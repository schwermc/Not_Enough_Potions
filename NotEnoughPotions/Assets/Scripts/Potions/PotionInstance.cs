using UnityEngine;

public class PotionInstance : MonoBehaviour
{
    public PotionData data;

    private string m_description;
    private string m_name;
    private PotionType m_type;
    private MeshRenderer mesh;
    private bool _mesh = true;

    public void Start()
    {
        m_name = data.name;
        m_description = data.description;
        m_type = data.type;
        mesh = GetComponent<MeshRenderer>();
    }

    public void SetData(PotionData data)
    {
        this.data = data;
    }
    
    public string getName()
    {
        return name;
    }
}
