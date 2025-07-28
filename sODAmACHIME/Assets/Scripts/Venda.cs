using UnityEngine;

public class Venda : StateMachineBehaviour
{
    private bool vendeu = false;
    private float timer = 0f;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var maquina = animator.GetComponent<MaquinaContext>();
        maquina.estadoAtual = "Venda";
        vendeu = false;
        timer = 0f;
        
        Debug.Log("*** ESTADO VENDA EXECUTADO - ESTOQUE ANTES: " + maquina.estoque + " ***");
        maquina.SoltarLata();
        Debug.Log("*** ESTADO VENDA - ESTOQUE DEPOIS: " + maquina.estoque + " ***");
        Debug.Log("Vendendo refrigerante...");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (!vendeu && timer > 2f)
        {
            vendeu = true;
            var maquina = animator.GetComponent<MaquinaContext>();
            if (maquina.estoque == 0)
            {
                Debug.Log("Venda finalizada - Indo para ToSemRefrigerante");
                animator.SetTrigger("ToSemRefrigerante");
            }
            else
            {
                Debug.Log("Venda finalizada - Indo para ToSemMoeda");
                animator.SetTrigger("ToSemMoeda");
            }
        }
    }
}