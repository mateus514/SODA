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

        Debug.Log("Estado: Manutenção");
    }

    // Não faça mudanças de estado automáticas aqui!
    // Deixe a saída do estado controlada pelo botão.
}