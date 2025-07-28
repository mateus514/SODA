using UnityEngine;

public class Manutencao : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "Manutencao";
        maquina.portaAberta.SetActive(true);
        maquina.painelEmpty.SetActive(false);
        maquina.painelOK.SetActive(false);
        Debug.Log("Modo manutenção ativado. Porta aberta.");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        
        // Se recebeu ToComMoeda (botão Inserir), adiciona lata
        if (animator.GetBool("ToComMoeda"))
        {
            animator.ResetTrigger("ToComMoeda");
            maquina.AdicionarLata();
        }
        
        // Se recebeu ToSemMoeda (botão Cancelar), vai para SemRefrigerante
        if (animator.GetBool("ToSemMoeda"))
        {
            animator.ResetTrigger("ToSemMoeda");
            animator.SetTrigger("ToSemRefrigerante");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.portaAberta.SetActive(false);
        Debug.Log("Saindo do modo manutenção. Porta fechada.");
    }
}