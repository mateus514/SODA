using UnityEngine;

public class Venda : StateMachineBehaviour
{
    private float timer = 0f;
    private bool vendeu = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "Venda";

        maquina.painelOK.SetActive(false);
        maquina.painelEmpty.SetActive(false);
        maquina.portaAberta.SetActive(false);

        maquina.SoltarLata(); // chama a latinha para sair

        timer = 0f;
        vendeu = false;

        Debug.Log("Estado: Venda. Dispensando refrigerante...");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > 2f && !vendeu)
        {
            vendeu = true;
            var maquina = animator.GetComponent<MaquinaContext>();

            if (maquina.estoque <= 0)
                animator.SetTrigger("ToSemRefrigerante");
            else
                animator.SetTrigger("ToSemMoeda");
        }
    }
}