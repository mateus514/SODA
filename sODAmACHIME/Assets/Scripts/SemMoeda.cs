using UnityEngine;

public class SemMoeda : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "SemMoeda";

        maquina.painelEmpty.SetActive(false);
        maquina.painelOK.SetActive(false);
        maquina.portaAberta.SetActive(false);

        maquina.AtualizarTextoEstoque();

        Debug.Log("Estado: Sem Moeda");
    }
}