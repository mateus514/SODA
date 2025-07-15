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
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();

        if (Input.GetKeyDown(KeyCode.C)) // Aqui poderia ser um flag ou chamada que sinaliza o cancelamento
        {
            animator.ResetTrigger("Cancelar"); // Limpa trigger, se existir
            animator.Play("SemMoeda"); // Força o estado SemMoeda sem transição
        }

        if (maquina.estoque < maquina.estoqueMaximo)
        {
            maquina.AdicionarLata();
        }
        else
        {
            Debug.LogWarning("⚠ Estoque máximo atingido!");
        }
    }
}
