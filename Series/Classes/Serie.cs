using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return "Id: " + this.Id +
                "\nGênero: " + this.Genero +
                "\nTitulo: " + this.Titulo +
                "\nDescrição: " + this.Descricao +
                "\nAno: " + this.Ano +
                "\nExcluído: " + this.Excluido;
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }

        public int GetId()
        {
            return this.Id;
        }

        public void Excluir()
        {
             this.Excluido = true;
        }

    }
}
