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

        Debug.Log("Aguardando moeda...");
    }
}