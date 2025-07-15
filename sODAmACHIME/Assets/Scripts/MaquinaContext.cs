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

    [Header("Dados da Máquina")]
    public int estoque = 3;
    [HideInInspector] public string estadoAtual = "";

    [Header("Prefab e Posição")]
    public GameObject lataPrefab;      // Prefab da latinha para instanciar
    public Transform posicaoSaida;     // Posição onde a latinha deve aparecer

    // Método para adicionar lata (usado no modo manutenção)
    public void AdicionarLata()
    {
        estoque++;
        AtualizarTextoEstoque();
    }
    
    // Atualiza o texto do estoque (usar após vender ou recarregar)
    public void AtualizarTextoEstoque()
    {
        if (textoEstoque != null)
            textoEstoque.text = "Estoque: " + estoque;
    }

    // Método para instanciar a latinha (usar no estado Venda)
    public void SoltarLata()
    {
        if (estoque > 0 && lataPrefab != null && posicaoSaida != null)
        {
            Instantiate(lataPrefab, posicaoSaida.position, Quaternion.identity);
            estoque--;
            AtualizarTextoEstoque();
        }
        else
        {
            Debug.LogWarning("Não foi possível soltar latinha: estoque, prefab ou posição inválidos.");
        }
    }
}
