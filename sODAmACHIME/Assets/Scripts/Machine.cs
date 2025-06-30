using UnityEngine;

public class Machine : MonoBehaviour
{
    public Animator animator;

    public int estoque = 3;
    private bool moedaInserida = false;
    private bool emManutencao = false;
    private bool emVenda = false;

    public void InserirMoeda()
    {
        if (emManutencao || emVenda) return;

        if (estoque <= 0)
        {
            animator.SetTrigger("ToSemRefrigerante");
            return;
        }

        if (!moedaInserida)
        {
            moedaInserida = true;
            animator.SetTrigger("ToComMoeda");
            Debug.Log("Moeda inserida.");
        }
    }

    public void Cancelar()
    {
        if (emManutencao || emVenda) return;

        if (moedaInserida)
        {
            moedaInserida = false;
            animator.SetTrigger("ToSemMoeda");
            Debug.Log("Compra cancelada.");
        }
    }

    public void Comprar()
    {
        if (emManutencao || emVenda || !moedaInserida) return;

        if (estoque > 0)
        {
            moedaInserida = false;
            estoque--;
            emVenda = true;
            animator.SetTrigger("ToVenda");

            // Espera o tempo da animação e volta para o estado certo
            Invoke(nameof(FinalizarVenda), 2f);
        }
        else
        {
            animator.SetTrigger("ToSemRefrigerante");
        }
    }

    private void FinalizarVenda()
    {
        emVenda = false;
        if (estoque <= 0)
        {
            animator.SetTrigger("ToSemRefrigerante");
        }
        else
        {
            animator.SetTrigger("ToSemMoeda");
        }
    }

    public void Manutencao()
    {
        if (emVenda) return;

        emManutencao = !emManutencao;

        if (emManutencao)
        {
            animator.SetTrigger("ToManutencao");
            Debug.Log("Entrando em modo manutenção.");
        }
        else
        {
            if (estoque <= 0)
                animator.SetTrigger("ToSemRefrigerante");
            else
                animator.SetTrigger("ToSemMoeda");

            Debug.Log("Saindo do modo manutenção.");
        }
    }

    // Este método pode ser chamado pelo botão INSERIR quando em manutenção
    public void RecarregarEstoque()
    {
        if (emManutencao)
        {
            estoque++;
            Debug.Log("Refrigerante adicionado. Estoque: " + estoque);
        }
    }
}