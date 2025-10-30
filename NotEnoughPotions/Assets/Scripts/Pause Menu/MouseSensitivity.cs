using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider _slider;
    public TMP_InputField _input;
    public MouseLook mouse;

    [SerializeField] Settings setting;

    private float maxValue;
    private float currentValue;
    private float minValue;

    void Start()
    {
        maxValue = _slider.maxValue;
        currentValue = setting.getDIP();
        minValue = _slider.minValue;

        _slider.value = currentValue;
        _input.text = currentValue.ToString("F0");
    }

    public void OnInputChange()
    {
        float input = float.Parse(_input.text);

        if (input < minValue)
        {
            input = minValue;
            _input.text = minValue.ToString();
        }

        if (input > maxValue)
        {
            input = maxValue;
            _input.text = maxValue.ToString();
        }

        currentValue = input;
        _slider.value = input;
        ChangeValue(input);
    }

    public void OnSliderChange()
    {
        float slider = _slider.value;
        currentValue = slider;
        _input.text = slider.ToString("F0");
        ChangeValue(slider);
    }

    void ChangeValue(float amount)
    {
        mouse.setSensitivity(amount);
    }

}