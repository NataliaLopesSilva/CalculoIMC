using CalculoIMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculoIMC.Controllers
{
    public class CalcularImcController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string altura, string peso)
        {
            try
            {
                Pessoa pessoa = new Pessoa();

                //Pega os parâmetros digitados pelo usuário
                pessoa.altura = Convert.ToDecimal(altura.Replace(".", ","));
                pessoa.peso = Convert.ToDecimal(peso.Replace(".", ","));

                //Calcula o imc
                pessoa.imc = pessoa.calculaImc(pessoa);

                //Redireciona para a tela de resultado
                return RedirectToAction("Resultado", new { imc = pessoa.imc });
            }
            catch (Exception)
            {
                ViewBag.msgErro = "Dados inválidos...";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Resultado(decimal imc)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.imc = imc;

            //A partir do imc calculado gera o resultado do usuário para mostrar na tela
            pessoa.resultado = pessoa.montaResultado(imc);

            return View(pessoa);
        }
    }
}