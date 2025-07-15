using UnityEngine;

public class MaquinaController : MonoBehaviour
{
    public Animator animator;
    public MaquinaContext contexto;

    public void InserirMoeda()
    {
        if (contexto.estadoAtual == "SemMoeda")
        {
            if (contexto.estoque > 0)
                animator.SetTrigger("ToComMoeda");
            else
                animator.SetTrigger("ToSemRefrigerante");
        }
        else if (contexto.estadoAtual == "Manutencao")
        {
            contexto.AdicionarLata();
        }
    }

    public void Cancelar()
    {
        if (contexto.estadoAtual == "ComMoeda" || contexto.estadoAtual == "Manutencao")
        {
            animator.SetTrigger("ToSemMoeda");  // Sair da manutenção ou cancelar compra
        }
    }

    public void Comprar()
    {
        if (contexto.estadoAtual == "ComMoeda")
            animator.SetTrigger("ToVenda");
    }

    public void Manutencao()
    {
        if (contexto.estadoAtual == "SemMoeda" || contexto.estadoAtual == "SemRefrigerante")
        {
            animator.SetTrigger("ToManutencao");
            Debug.Log("Cliquei no botão MANUTENÇÃO");
        }
    }
}