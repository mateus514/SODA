using UnityEngine;

public class ComMoeda : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "ComMoeda";

        maquina.painelOK.SetActive(true);
        maquina.painelEmpty.SetActive(false);
        maquina.portaAberta.SetActive(false);

        Debug.Log("Com moeda. Pronto para comprar.");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.painelOK.SetActive(false);
    }
}