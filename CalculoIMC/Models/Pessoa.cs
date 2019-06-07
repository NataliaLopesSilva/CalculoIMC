using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculoIMC.Models
{
    public class Pessoa
    {
        public decimal altura { get; set; }
        public decimal peso { get; set; }
        public decimal imc { get; set; }
        public string resultado { get; set; }

        /// <summary>
        /// Realiza o cálculo do imc
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns>retorna o valor do imc</returns>
        public decimal calculaImc(Pessoa pessoa)
        {
            try
            {
                decimal resultadoImc = 0;

                //Calcula o imc
                resultadoImc = Math.Round((pessoa.peso / (pessoa.altura * pessoa.altura)), 2);

                return resultadoImc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// A partir do valor do imc define o resultado
        /// </summary>
        /// <param name="imc"></param>
        /// <returns>retorna o resultado da pessoa</returns>
        public string montaResultado(decimal imc)
        {
            try
            {
                string resultado = "";

                if (imc < Convert.ToDecimal(18.5))
                {
                    resultado = "abaixo do peso";
                }
                else if (imc >= Convert.ToDecimal(18.5) && imc <= Convert.ToDecimal(24.9))
                {
                    resultado = "peso normal";
                }
                else if (imc >= Convert.ToDecimal(25) && imc <= Convert.ToDecimal(29.9))
                {
                    resultado = "sobrepeso";
                }
                else if (imc >= 30)
                {
                    resultado = "obesidade";
                }

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}