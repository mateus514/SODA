using UnityEngine;
using UnityEngine.UI;

public class MaquinaContext : MonoBehaviour
{
    public Animator animator;

    [Header("UI da Máquina")]
    public GameObject painelEmpty;
    public GameObject painelOK;
    public GameObject portaAberta;
    public Text textoEstoque;

    [Header("Estado Atual da Máquina")]
    public int estoque = 3;
    [HideInInspector] public string estadoAtual = "";
}