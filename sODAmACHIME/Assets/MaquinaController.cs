using UnityEngine;

public class MaquinaController : MonoBehaviour
{
    public Animator animator;

    public void InserirMoeda()
    {
        animator.SetTrigger("ToComMoeda");  // botão inserir moeda
    }

    public void Cancelar()
    {
        animator.SetTrigger("ToSemMoeda");  // botão cancelar
    }

    public void Comprar()
    {
        animator.SetTrigger("Venda");     // botão comprar
    }

    public void Manutencao()
    {
        animator.SetTrigger("ToManutencao"); // botão manutenção
    }
    public void SemRefrigerante()
    {
        animator.SetTrigger("ToSemRefrigerante"); // botão manutenção
    }
}