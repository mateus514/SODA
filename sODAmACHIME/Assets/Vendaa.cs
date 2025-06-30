using UnityEngine;

public class Vendaa : StateMachineBehaviour
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
        maquina.estoque--;

        if (maquina.textoEstoque != null)
            maquina.textoEstoque.text = "Estoque: " + maquina.estoque;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();

        timer += Time.deltaTime;
        if (timer > 2f && !vendeu)
        {
            vendeu = true;
            if (maquina.estoque <= 0)
                animator.SetTrigger("ToSemRefrigerante");
            else
                animator.SetTrigger("ToSemMoeda");
        }
    }
}
