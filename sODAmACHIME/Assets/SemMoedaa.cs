using UnityEngine;

public class SemMoedaa : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "SemMoeda";

        maquina.painelEmpty.SetActive(false);
        maquina.painelOK.SetActive(false);
        maquina.portaAberta.SetActive(false);

        Debug.Log("Estado: Sem Moeda");
    }

    // INSERIR MOEDA
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.I)) // ou botão da UI
        {
            var maquina = animator.GetComponent<MaquinaContext>();
            if (maquina.estoque > 0)
            {
                animator.SetTrigger("ToComMoeda");
            }
            else
            {
                animator.SetTrigger("ToSemRefrigerante");
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("ToManutencao");
        }
    }
}
