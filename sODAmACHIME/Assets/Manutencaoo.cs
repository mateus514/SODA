using UnityEngine;
class ManutencaoState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "Manutencao";

        maquina.portaAberta.SetActive(true);
        Debug.Log("Modo Manutenção ativo");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();

        if (Input.GetKeyDown(KeyCode.I))
        {
            maquina.estoque++;
            maquina.textoEstoque.text = "Estoque: " + maquina.estoque;
            Debug.Log("Adicionou 1 refrigerante. Estoque: " + maquina.estoque);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (maquina.estoque <= 0)
                animator.SetTrigger("ToSemRefrigerante");
            else
                animator.SetTrigger("ToSemMoeda");
        }
    }
}

