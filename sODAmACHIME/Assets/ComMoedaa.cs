using UnityEngine;

public class ComMoedaa : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "ComMoeda";

        maquina.painelOK.SetActive(true);
        Debug.Log("Estado: Com Moeda");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("ToVenda");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("ToSemMoeda");
        }
    }
}