using UnityEngine;

public class SemRefrigerante : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "SemRefrigerante";
        
        // Apenas configura a UI - NÃO MEXE NO ESTOQUE
        maquina.painelEmpty.SetActive(true);
        maquina.painelOK.SetActive(false);
        maquina.portaAberta.SetActive(false);
        
        Debug.Log("=== ENTROU EM SemRefrigerante - Estoque: " + maquina.estoque + " ===");
        maquina.AtualizarTextoEstoque();
        
        // Se tem estoque, vai direto para SemMoeda
        if (maquina.estoque > 0)
        {
            Debug.Log("Tem estoque, indo para SemMoeda imediatamente");
            animator.SetTrigger("ToSemMoeda");
        }
        else
        {
            Debug.Log("Sem estoque, ficando em SemRefrigerante");
        }
    }
}