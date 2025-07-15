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
     if (contexto.estadoAtual == "ComMoeda")
     {
         animator.SetTrigger("ToSemMoeda");
     }
     else if (contexto.estadoAtual == "Manutencao")
     {
         animator.SetTrigger("ToSemMoeda");  // Sair da manutenção
     }
 }

    public void Comprar()
    {
        if (contexto.estadoAtual == "ComMoeda")
            animator.SetTrigger("ToVenda");
    }

    public void Manutencao()
    {
        if (contexto.estadoAtual == "SemMoeda")
            animator.SetTrigger("ToManutencao");
    }
    
}