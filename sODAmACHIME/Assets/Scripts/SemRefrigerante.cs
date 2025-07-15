using UnityEngine;

public class SemRefrigerante : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "SemRefrigerante";

        maquina.painelEmpty.SetActive(true);
        maquina.painelOK.SetActive(false);
        maquina.portaAberta.SetActive(false);

        Debug.LogWarning("⚠️ Máquina vazia!");
    }
}