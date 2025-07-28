using UnityEngine;

public class SemMoeda : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "SemMoeda";
        maquina.painelOK.SetActive(false);
        maquina.painelEmpty.SetActive(false);
        maquina.portaAberta.SetActive(false);
        
        maquina.AtualizarTextoEstoque();
        Debug.Log("Aguardando moeda... Estoque: " + maquina.estoque);
        
        // APENAS verifica se estoque = 0 e vai para SemRefrigerante
        // NÃO consome refrigerante aqui
        if (maquina.estoque <= 0)
        {
            Debug.Log("Estoque zerado, indo para SemRefrigerante");
            animator.SetTrigger("ToSemRefrigerante");
        }
    }
}