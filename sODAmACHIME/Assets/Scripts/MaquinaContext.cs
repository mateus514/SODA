using UnityEngine;
using UnityEngine.UI;

public class MaquinaContext : MonoBehaviour
{
    public Animator animator;

    [Header("UI da Máquina")]
    public GameObject painelEmpty;     // Painel com aviso "EMPTY"
    public GameObject painelOK;        // Painel com aviso "OK"
    public GameObject portaAberta;     // Porta aberta (modo manutenção)
    public Text textoEstoque;          // Texto "Estoque: X"

    [Header("Estado Atual da Máquina")]
    public int estoque = 3;
    [HideInInspector] public string estadoAtual = "";

    public GameObject lataPrefab;      // Prefab da latinha
    public Transform posicaoSaida;     // Posição onde a latinha sai

    // Atualiza o texto na tela
    public void AtualizarTextoEstoque()
    {
        if (textoEstoque != null)
            textoEstoque.text = "Estoque: " + estoque;
    }

    // Adiciona uma latinha (usado no modo manutenção)
    public void AdicionarLata()
    {
        estoque++;
        AtualizarTextoEstoque();
    }

    // Solta uma latinha se houver estoque
    public void SoltarLata()
    {
        if (estoque > 0 && lataPrefab != null && posicaoSaida != null)
        {
            Instantiate(lataPrefab, posicaoSaida.position, Quaternion.identity);
            estoque--;
            AtualizarTextoEstoque();
        }
    }
}