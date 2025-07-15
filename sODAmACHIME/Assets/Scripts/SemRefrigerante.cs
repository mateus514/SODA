using UnityEngine;
class SemRefrigerantee : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "SemRefrigerante";

        maquina.painelEmpty.SetActive(true);
        Debug.Log("Máquina está vazia!");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("ToManutencao");
        }
    }
}