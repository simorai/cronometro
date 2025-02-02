﻿using System;

namespace WindowsFormsAppBalao
{
    /// <summary>
    /// Representa um balão com propriedades de cor, direção e altura.
    /// </summary>
    public class Balao
    {
        #region Atributos

        private string _cor;
        private string _direcao;
        private int _altura;

        #endregion Atributos

        #region Propriedades

        public string Cor
        {
            get {  return _cor; }
            set { _cor = value; }
        }

        public string Direcao
        {
            get { return _direcao; }
            set { _direcao = value; }
        }

        public int Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }

        #endregion Propriedades

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe Balao.
        /// </summary>
        /// <param name="corInicial">A cor inicial do balão. Pode ser "vermelho", "azul", "verde" ou outra cor válida.</param>
        /// <param name="direcaoInicial">A direção inicial do balão (por exemplo, "Norte", "Sul", "Leste", "Oeste").</param>
        /// <param name="alturaInicial">A altura inicial do balão em metros. Se for negativa, será ajustada para zero.</param>
        /// <remarks>
        /// Este construtor inicializa um novo objeto Balao com as propriedades especificadas.
        /// A altura é garantida como sendo não negativa, usando Math.Max para ajustar valores negativos para zero.
        /// </remarks>
        public Balao(string corInicial, string direcaoInicial, int alturaInicial)
        {
            Cor = corInicial;
            Direcao = direcaoInicial;
            Altura = Math.Max(0, alturaInicial); // Garante que a altura seja maior ou igual a zero
        }

        #endregion Construtores

        #region Metodos

        /// <summary>
        /// Define uma nova cor para o balão.
        /// </summary>
        /// <param name="novaCor">A nova cor a ser atribuída ao balão. Deve ser "vermelho", "azul" ou "verde" (não sensível a maiúsculas/minúsculas).</param>
        /// <returns>
        /// Um valor booleano indicando se a operação foi bem-sucedida:
        /// <list type="bullet">
        /// <item><description><c>true</c> se a cor foi definida com sucesso (cor válida).</description></item>
        /// <item><description><c>false</c> se a cor fornecida não é válida e, portanto, não foi definida.</description></item>
        /// </list>
        /// </returns>
        public bool SetCor(string novaCor)
        {
            novaCor = novaCor.ToLower();
            if (novaCor == "vermelho" || novaCor == "azul" || novaCor == "verde")
            {
                Cor = novaCor;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obtém o nome do recurso de imagem correspondente à cor atual do balão.
        /// </summary>
        /// <returns>
        /// Uma string representando o nome do recurso de imagem, ou null se a cor não for reconhecida.
        /// Os possíveis valores de retorno são:
        /// <list type="bullet">
        ///     <item><description>"balao_vermelho" para a cor vermelha</description></item>
        ///     <item><description>"balao_azul" para a cor azul</description></item>
        ///     <item><description>"balao_verde" para a cor verde</description></item>
        ///     <item><description>null para qualquer outra cor</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// Este método usa a cor atual do balão (_cor) para determinar qual recurso de imagem deve ser usado.
        /// A comparação é feita de forma case-insensitive (não diferencia maiúsculas de minúsculas).
        /// Se a cor não for reconhecida (diferente de vermelho, azul ou verde), o método retorna null.
        /// </remarks>
        public string GetImagemRecurso()
        {
            switch (Cor.ToLower())
            {
                case "vermelho":
                    return "balao_vermelho";
                case "azul":
                    return "balao_azul";
                case "verde":
                    return "balao_verde";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Aumenta a altura do balão em uma quantidade especificada, garantindo que não exceda a altura máxima permitida.
        /// </summary>
        /// <param name="metros">A quantidade de metros que o balão deve subir.</param>
        /// <param name="alturaMaxima">A altura máxima que o balão pode atingir.</param>
        /// <remarks>
        /// Este método verifica se a quantidade de metros a ser adicionada é positiva.
        /// Se a nova altura calculada exceder a altura máxima, a altura do balão é ajustada
        /// para a altura máxima. Caso contrário, a nova altura é definida normalmente.
        /// A direção do balão é atualizada para "Norte".
        /// </remarks>
        public void Subir(int metros, int alturaMaxima)
        {
            if (metros > 0)
            {
                // Calcula a nova altura
                int novaAltura = Altura + metros;
                // Verifica se a nova altura excede a altura máxima
                if (novaAltura > alturaMaxima)
                {
                    Altura = alturaMaxima; // Ajusta para a altura máxima
                }
                else
                {
                    Altura = novaAltura; // Define a nova altura se não exceder
                }                
                Direcao = "Norte";
            }
        }

        /// <summary>
        /// Diminui a altura do balão e atualiza sua direção para "Sul".
        /// </summary>
        /// <param name="metros">O número de metros que o balão deve descer. Deve ser um valor positivo.</param>
        /// <remarks>
        /// Este método só altera a altura e a direção do balão se o valor de metros for maior que zero.
        /// A altura do balão é decrementada pelo valor especificado em metros, mas nunca ficará abaixo de zero.
        /// A direção do balão é sempre definida como "Sul" quando ele desce.
        /// </remarks>
        public void Descer(int metros)
        {
            if (metros > 0)
            {
                // Calcula a nova altura do balão
                // Math.Max garante que a altura não seja menor que zero
                Altura = Math.Max(0, _altura - metros);
                // Explicação detalhada:
                // 1. _altura - metros: Subtrai o número de metros da altura atual
                // 2. Math.Max(0, ...): Compara o resultado da subtração com zero
                //    e retorna o maior valor, evitando alturas negativas
                Direcao = "Sul";
            }
            // Se metros <= 0, o método não faz nada, evitando movimentos inválidos
        }

        /// <summary>
        /// Obtém uma representação em string do estado atual do balão.
        /// </summary>
        /// <returns>
        /// Uma string contendo informações sobre a cor, direção e altura do balão.
        /// O formato da string é:
        /// "Cor: [cor]
        /// Direção: [direção]
        /// Altura: [altura] metros"
        /// </returns>
        /// <remarks>
        /// Este método fornece uma visão geral rápida do estado atual do balão,
        /// combinando todas as suas propriedades principais em uma única string.
        /// As informações são apresentadas em múltiplas linhas para fácil leitura.
        /// </remarks>
        public string GetEstado()
        {
            return $"Cor: {Cor}\nDireção: {Direcao}\nAltura: {Altura} metros";
        }

        #endregion Metodos
    }
}
