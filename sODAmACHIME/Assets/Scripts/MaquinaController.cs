using UnityEngine;

public class MaquinaController : MonoBehaviour
{
    public Animator animator;

    public void InserirMoeda()
    {
        animator.SetTrigger("ToComMoeda");
    }

    public void Cancelar()
    {
        animator.SetTrigger("ToSemMoeda");
    }

    public void Comprar()
    {
        animator.SetTrigger("ToVenda");
    }

    public void Manutencao()
    {
        animator.SetTrigger("ToManutencao");
    }
}