using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class FilmeSerieRepositorio : IRepositorio<FilmeSerie>
	{
        private List<FilmeSerie> listaFilmeSerie = new List<FilmeSerie>();
		
		public void Atualizar(int id, FilmeSerie objeto)
		{
			listaFilmeSerie[id] = objeto;
		}

		public void Excluir(int id)
		{
			listaFilmeSerie[id].Excluir();
		}

		public void Inserir(FilmeSerie objeto)
		{
			listaFilmeSerie.Add(objeto);
		}

		public List<FilmeSerie> Lista()
		{
			return listaFilmeSerie;
		}

		public int ProximoId()
		{
			return listaFilmeSerie.Count;
		}

		public FilmeSerie RetornaPorId(int id)
		{
			return listaFilmeSerie[id];
		}
	}
}