using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    class Series : EntidadeBase
    {
        private Genero genero { get; set; }
        private string Titulo {  get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Series(int Id, Genero genero, string Titulo, string Descricao, int Ano) {
            this.Id = Id;
            this.genero = genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false; 

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluído? " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            if (this.Excluido == true)
            {
                return "*Excluído*";
            }
            return this.Titulo;
        }

        public int retornaId()
        {
            if (this.Excluido == true)
            {
                return 00000;
            }
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }
    }
}
