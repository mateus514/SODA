using UnityEngine;

public class Manutencao : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "Manutencao";

        maquina.painelOK.SetActive(false);
        maquina.painelEmpty.SetActive(false);
        maquina.portaAberta.SetActive(true);

        Debug.Log("Entrou no estado Manutenção");
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.portaAberta.SetActive(false);
    }
}