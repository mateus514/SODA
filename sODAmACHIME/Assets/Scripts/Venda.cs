using UnityEngine;

public class Venda : StateMachineBehaviour
{
    private float timer = 0f;
    private bool vendeu = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "Venda";

        Debug.Log("Estado: Venda. Dispensando refrigerante...");
        vendeu = false;
        timer = 0f;

        maquina.painelOK.SetActive(false);

        // Solta a lata e já atualiza o estoque
        maquina.SoltarLata();
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