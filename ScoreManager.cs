using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text textValue;

    private int _score;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeScore(int modifier)
    {
        _score += modifier;
        textValue.text = _score.ToString();
    }

}
